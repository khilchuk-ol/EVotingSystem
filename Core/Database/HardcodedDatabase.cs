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
                    Name = "aa",
                    Surname = "aa",
                    BirthDate = new DateOnly(1990, 1, 1),
                    CanVote = true,
                },
                new Voter()
                {
                    GovernmentId = "UA121214",
                    Name = "bb",
                    Surname = "bb",
                    BirthDate = new DateOnly(2010, 1, 1),
                    CanVote = false,
                },
                new Voter()
                {
                    GovernmentId = "UA121215",
                    Name = "cc",
                    Surname = "cc",
                    BirthDate = new DateOnly(1990, 1, 1),
                    CanVote = true,
                },
                new Voter()
                {
                    GovernmentId = "UA121216",
                    Name = "dd",
                    Surname = "dd",
                    BirthDate = new DateOnly(1990, 1, 1),
                    CanVote = true,
                },
                new Voter()
                {
                    GovernmentId = "UA121217",
                    Name = "ee",
                    Surname = "ee",
                    BirthDate = new DateOnly(1990, 1, 1),
                    CanVote = true,
                },
                new Voter()
                {
                    GovernmentId = "UA121217",
                    Name = "ff",
                    Surname = "ff",
                    BirthDate = new DateOnly(1990, 1, 1),
                    CanVote = true,
                },
                new Voter()
                {
                    GovernmentId = "UA121217",
                    Name = "gg",
                    Surname = "gg",
                    BirthDate = new DateOnly(1990, 1, 1),
                    CanVote = true,
                },
            });
        }

        public IRepository<Bulletin> Bulletins => bulletins;

        public IRepository<Candidate> Candidates => candidates;

        public IRepository<Voter> Voters => voters;
    }
}
