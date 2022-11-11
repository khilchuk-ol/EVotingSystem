using Core.Database;
using Core.Entities;
using Shared.RsaEncryption;
using Shared.Mappers;
using Shared.Models;
using Shared.ValueObjects;

namespace Core.Services
{
    public class SimpleServerVotingService : IServerVotingService
    {
        private readonly IRsaEncryptionService rsaEncryptionService;
        private readonly IDatabase database;
        private readonly IMapper<Candidate, CandidateModel> candidateEntityToModelMapper;
        private readonly IMapper<string, BulletinModel> stringToBulletinModelMapper;

        public RsaKey PublicKey => rsaEncryptionService.PublicKey;

        public SimpleServerVotingService(
            IRsaEncryptionService rsaEncryptionService,
            IDatabase database,
            IMapper<Candidate, CandidateModel> candidateEntityToModelMapper,
            IMapper<string, BulletinModel> stringToBulletinModelMapper)
        {
            this.rsaEncryptionService = rsaEncryptionService;
            this.database = database;
            this.candidateEntityToModelMapper = candidateEntityToModelMapper;
            this.stringToBulletinModelMapper = stringToBulletinModelMapper;
        }

        public async Task<IEnumerable<CandidateModel>> GetAllCandidatesAsync()
        {
            return (await database.Candidates.GetAllAsync())
                .Select(candidateEntityToModelMapper.Map).ToList();
        }

        public async Task<ResultCode> Vote(string encryptedBulletin, string eds, RsaKey userOpenKey)
        {
            var decryptedBulletinTask = rsaEncryptionService.ApplyPrivateKeyAsync(encryptedBulletin);
            var hashedBulletinEdsTask = rsaEncryptionService.ApplyPublicKeyAsync(eds, userOpenKey);
            var decryptedBulletin = await decryptedBulletinTask;
            var hashedBulletinVoteTask = rsaEncryptionService.Hash(decryptedBulletin, userOpenKey);
            if (!Equals(await hashedBulletinVoteTask, await hashedBulletinEdsTask)) return ResultCode.DataMismatch;

            var bulletin = stringToBulletinModelMapper.Map(decryptedBulletin);

            var checkRes = await ValidateVote(bulletin);
            if (checkRes == ResultCode.Success) ApplyVote(bulletin);

            return checkRes;
        }

        private async Task<ResultCode> ValidateVote(BulletinModel bulletin)
        {
            // Check if voter exists and can vote
            var voter = (await database.Voters.GetAllAsync()).FirstOrDefault(v => 
                v.GovernmentId == bulletin.GovernmentId &&
                v.Name == bulletin.Name &&
                v.Surname == bulletin.Surname &&
                v.BirthDate == bulletin.BirthDate);
            if (voter == default) return ResultCode.VoterNotFound;
            if (!voter.CanVote) return ResultCode.VoterCantVote;

            // Check if candidate exists
            if (!(await database.Candidates.GetAllAsync()).Any(c => 
                c.Id == bulletin.CandidateId
            )) return ResultCode.CandidateNotFound;

            // Check if candidate sent valid bulletin
            if ((await database.Bulletins.GetAllAsync()).Any(b => 
                b.VoterId == bulletin.GovernmentId
            )) return ResultCode.VoterAlreadyVoted;

            return ResultCode.Success;
        }

        private async void ApplyVote(BulletinModel bulletinModel)
        {
            Bulletin bulletin = new()
            {
                CandidateId = bulletinModel.CandidateId,
                VoterId = bulletinModel.GovernmentId
            };
            await database.Bulletins.CreateAsync(bulletin);
        }
    }
}
