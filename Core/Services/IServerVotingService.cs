using Shared.RsaEncryption;
using Shared.Models;
using Shared.ValueObjects;

namespace Core.Services
{
    public interface IServerVotingService
    {
        RsaKey PublicKey { get; }

        Task<IEnumerable<CandidateModel>> GetAllCandidatesAsync();
        Task<ResultCode> Vote(string encryptedBulletin, string eds, RsaKey userOpenKey);
    }
}
