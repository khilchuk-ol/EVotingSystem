using Shared.Models;

namespace Client.Services
{
    public interface IClientVotingService
    {
        Task<IEnumerable<CandidateModel>> GetAllCandidatesAsync();
        Task Vote(BulletinModel bulletin);
    }
}