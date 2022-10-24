using Core.Services;
using Shared.Encryption;
using Shared.Mappers;
using Shared.Models;

namespace Client
{
    public class DefaultClientVotingService : IClientVotingService
    {
        private readonly IServerVotingService votingService;
        private readonly IMapper<BulletinModel, string> bulletinModelToStringMapper;
        private readonly IRsaEncryptionService rsaEncryptionService;
        private readonly IMapper<string, string> hasher;

        public DefaultClientVotingService(
            IServerVotingService votingService,
            IMapper<BulletinModel, string> bulletinModelToStringMapper,
            IRsaEncryptionService rsaEncryptionService,
            IMapper<string, string> hasher)
        {
            this.votingService = votingService;
            this.bulletinModelToStringMapper = bulletinModelToStringMapper;
            this.rsaEncryptionService = rsaEncryptionService;
            this.hasher = hasher;
        }

        public async Task<IEnumerable<CandidateModel>> GetAllCandidatesAsync()
        {
            return await votingService.GetAllCandidatesAsync();
        }

        public async Task Vote(BulletinModel bulletin)
        {
            var stringBulletin = bulletinModelToStringMapper.Map(bulletin);
            var serverKey = votingService.PublicKey;
            var encryptedBulletinTask = rsaEncryptionService.ApplyPublicKeyAsync(stringBulletin, serverKey);
            var hashedBulletin = hasher.Map(stringBulletin);
            var edsTask = rsaEncryptionService.ApplyPrivateKeyAsync(hashedBulletin);
            var userKey = rsaEncryptionService.PublicKey;
            await votingService.Vote(await encryptedBulletinTask, await edsTask, userKey);
        }
    }
}
