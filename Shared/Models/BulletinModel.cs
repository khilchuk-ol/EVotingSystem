namespace Shared.Models
{
    public class BulletinModel
    {
        public string GovernmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public int CandidateId { get; set; }
    }
}
