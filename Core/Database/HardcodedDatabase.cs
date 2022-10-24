using Core.Entities;

namespace Core.Database
{
    public class HardcodedDatabase : IDatabase
    {
        private readonly IRepository<Bulletin> bulletins;
        private readonly IRepository<Candidate> candidates;
        private readonly IRepository<Voter> voters;

        public HardcodedDatabase()
        {
            bulletins = new HardcodedRepository<Bulletin>(Array.Empty<Bulletin>());
            candidates = new HardcodedRepository<Candidate>(new Candidate[]
            {
                new Candidate() { Id = 1, Name = "Thelensky" },
                new Candidate() { Id = 2, Name = "Prytula" },
                new Candidate() { Id = 4, Name = "Sternenko" },
            });
            voters = new HardcodedRepository<Voter>(new Voter[]
            {
                new Voter()
                {
                    GovernmentId = "UA121212",
                    Name = "Olena",
                    Surname = "Khilchuk",
                    BirthDate = new DateOnly(2002, 09, 23),
                    CanVote = true,
                },
                new Voter()
                {
                    GovernmentId = "UA121213",
                    Name = "",
                    Surname = "",
                    BirthDate = new DateOnly(),
                    CanVote = true,
                },
                new Voter()
                {
                    GovernmentId = "UA121214",
                    Name = "",
                    Surname = "",
                    BirthDate = new DateOnly(),
                    CanVote = true,
                },
                new Voter()
                {
                    GovernmentId = "UA121215",
                    Name = "",
                    Surname = "",
                    BirthDate = new DateOnly(),
                    CanVote = true,
                },
                new Voter()
                {
                    GovernmentId = "UA121216",
                    Name = "",
                    Surname = "",
                    BirthDate = new DateOnly(),
                    CanVote = true,
                },
                new Voter()
                {
                    GovernmentId = "UA121217",
                    Name = "",
                    Surname = "",
                    BirthDate = new DateOnly(),
                    CanVote = true,
                },
            });
        }

        public IRepository<Bulletin> Bulletins => bulletins;

        public IRepository<Candidate> Candidates => candidates;

        public IRepository<Voter> Voters => voters;
    }
}
