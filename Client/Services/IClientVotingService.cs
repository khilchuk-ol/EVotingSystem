using Shared.Models;
using Shared.ValueObjects;

namespace Client.Services
{
    public interface IClientVotingService
    {
        Task<IEnumerable<CandidateModel>> GetAllCandidatesAsync();
        Task<ResultCode> Vote(BulletinModel bulletin);
    }
}