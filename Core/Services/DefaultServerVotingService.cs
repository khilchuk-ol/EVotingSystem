using Core.Database;
using Core.Entities;
using Shared.Encryption;
using Shared.Mappers;
using Shared.Models;

namespace Core.Services
{
    public class DefaultServerVotingService : IServerVotingService
    {
        private readonly IRsaEncryptionService rsaEncryptionService;
        private readonly IDatabase database;
        private readonly IMapper<Candidate, CandidateModel> candidateEntityToModelMapper;
        private readonly IMapper<string, string> hasher;
        private readonly IMapper<string, BulletinModel> stringToBulletinModelMapper;

        public RsaKey PublicKey => rsaEncryptionService.PublicKey;

        public DefaultServerVotingService(
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

        public async Task Vote(string encryptedBulletin, string eds, RsaKey userOpenKey)
        {
            var decryptedBulletinTask = rsaEncryptionService.ApplyPrivateKeyAsync(encryptedBulletin);
            var hashedBulletinEdsTask = rsaEncryptionService.ApplyPublicKeyAsync(eds, userOpenKey);
            var decryptedBulletin = await decryptedBulletinTask;
            var hashedBulletinVoteTask = rsaEncryptionService.Hash(decryptedBulletin, userOpenKey);
            if (!Equals(await hashedBulletinVoteTask, await hashedBulletinEdsTask)) return;

            var bulletin = stringToBulletinModelMapper.Map(decryptedBulletin);
            if (await ValidateVote(bulletin)) ApplyVote(bulletin);
        }

        private async Task<bool> ValidateVote(BulletinModel bulletin)
        {
            // Check if voter exists and can vote
            var voter = (await database.Voters.GetAllAsync()).FirstOrDefault(v => 
                v.GovernmentId == bulletin.GovernmentId &&
                v.Name == bulletin.Name &&
                v.Surname == bulletin.Surname &&
                v.BirthDate == bulletin.BirthDate);
            if (voter == default || !voter.CanVote) return false;

            // Check if candidate exists
            if (!(await database.Candidates.GetAllAsync()).Any(c => 
                c.Id == bulletin.CandidateId
            )) return false;

            // Check if bulletin doesn't exist
            if ((await database.Bulletins.GetAllAsync()).Any(b => 
                b.CandidateId == bulletin.CandidateId &&
                b.VoterId == bulletin.GovernmentId
            )) return false;

            return true;
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
