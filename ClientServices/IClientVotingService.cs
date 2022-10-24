using Shared.Models;

namespace Client
{
    public interface IClientVotingService
    {
        Task<IEnumerable<CandidateModel>> GetAllCandidatesAsync();
        Task Vote(BulletinModel bulletin);
    }
}