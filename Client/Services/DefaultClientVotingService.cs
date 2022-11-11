using Core.Services;
using Shared.Encryption;
using Shared.Mappers;
using Shared.Models;
using Shared.ValueObjects;

namespace Client.Services
{
    public class DefaultClientVotingService : IClientVotingService
    {
        private readonly IServerVotingService votingService;
        private readonly IMapper<BulletinModel, string> bulletinModelToStringMapper;
        private readonly IRsaEncryptionService rsaEncryptionService;

        public DefaultClientVotingService(
            IServerVotingService votingService,
            IMapper<BulletinModel, string> bulletinModelToStringMapper,
            IRsaEncryptionService rsaEncryptionService)
        {
            this.votingService = votingService;
            this.bulletinModelToStringMapper = bulletinModelToStringMapper;
            this.rsaEncryptionService = rsaEncryptionService;
        }

        public async Task<IEnumerable<CandidateModel>> GetAllCandidatesAsync()
        {
            return await votingService.GetAllCandidatesAsync();
        }

        public async Task<ResultCode> Vote(BulletinModel bulletin)
        {
            var stringBulletin = bulletinModelToStringMapper.Map(bulletin);
            var serverKey = votingService.PublicKey;
            var encryptedBulletinTask = rsaEncryptionService.ApplyPublicKeyAsync(stringBulletin, serverKey);
            var userKey = rsaEncryptionService.PublicKey;
            var hashedBulletinTask = rsaEncryptionService.Hash(stringBulletin, userKey);
            var edsTask = rsaEncryptionService.ApplyPrivateKeyAsync(await hashedBulletinTask);
            return await votingService.Vote(await encryptedBulletinTask, await edsTask, userKey);
        }
    }
}
