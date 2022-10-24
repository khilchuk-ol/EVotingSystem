using Core.Entities;

namespace Core.Database
{
    public interface IDatabase
    {
        IRepository<Bulletin> Bulletins { get; }
        IRepository<Candidate> Candidates { get; }
        IRepository<Voter> Voters { get; }
    }
}
