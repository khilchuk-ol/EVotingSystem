using Client.Services;
using Shared.Models;
using Shared.ValueObjects;

namespace ConsoleVoting
{
    internal class Terminal
    {
        private readonly IClientVotingService votingService;

        public Terminal(IClientVotingService votingService)
        {
            this.votingService = votingService;
        }

        public async Task Loop()
        {
            while (true)
            {
                WelcomeMessage();
                var res = await votingService.Vote(await ReadInputs());
                PrintResult(res);
                Restart();
            }
        }

        private void Restart()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.Clear();
        }

        private async Task<BulletinModel> ReadInputs()
        {
            BulletinModel bulletin = new();
            bulletin.GovernmentId = ReadString("Government ID");
            bulletin.Surname = ReadString("Surname");
            bulletin.Name = ReadString("Name");
            bulletin.BirthDate = ReadDate("Birth Day (YYYY/MM/DD)");
            bulletin.CandidateId = await ReadCandidate();
            return bulletin;
        }

        private async Task<int> ReadCandidate()
        {
            var candidates = await votingService.GetAllCandidatesAsync();
            foreach (var item in candidates)
            {
                Console.WriteLine(item);
            }
            Console.Write("Enter Id of candidate you want to vote for: ");
            int candidateId;
            var input = Console.ReadLine();
            while (!int.TryParse(input, out candidateId))
            {
                Console.WriteLine("Invalid input, try again");
                Console.Write("Enter Id of candidate you want to vote for: ");
                input = Console.ReadLine();
            }
            return candidateId;
        }

        private DateOnly ReadDate(string v)
        {
            Console.Write($"Enter your {v}: ");
            DateOnly date;
            var input = Console.ReadLine();
            while (!DateOnly.TryParse(input, out date))
            {
                Console.WriteLine("Invalid input, try again");
                Console.Write($"Enter your {v}: ");
                input = Console.ReadLine();
            }
            return date;
        }

        private string ReadString(string v)
        {
            Console.Write($"Enter your {v}: ");
            var input = Console.ReadLine();
            while (input == null)
            {
                Console.WriteLine("Invalid input, try again");
                Console.Write($"Enter your {v}: ");
                input = Console.ReadLine();
            }
            return input;
        }

        private void WelcomeMessage()
        {
            Console.WriteLine("Welcome");
        }

        private void PrintResult(ResultCode code)
        {
            if (code != ResultCode.Success)
            {
                Console.Write("Could not perform voting. Error: ");
            }
            
            Console.WriteLine(code.ToString());
        }
    }
}
