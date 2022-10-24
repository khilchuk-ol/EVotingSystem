namespace Core.Entities
{
    public class Voter
    {
        public string GovernmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }

        public bool CanVote { get; set; }
    }
}
