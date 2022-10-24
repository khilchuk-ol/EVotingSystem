using Shared.Encryption;
using Shared.Models;

namespace Core.Services
{
    public interface IServerVotingService
    {
        RsaKey PublicKey { get; }

        Task<IEnumerable<CandidateModel>> GetAllCandidatesAsync();
        Task Vote(string encryptedBulletin, string eds, RsaKey userOpenKey);
    }
}
