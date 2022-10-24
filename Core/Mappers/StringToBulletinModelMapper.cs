using Shared.Mappers;
using Shared.Models;

namespace Core.Mappers
{
    public class StringToBulletinModelMapper : IMapper<string, BulletinModel>
    {
        public BulletinModel Map(string entity)
        {
            var bulletin = entity.Split('|');
            if (bulletin.Length != typeof(BulletinModel).GetProperties().Length) 
                throw new ArgumentException("Bad input", nameof(entity));

            return new BulletinModel()
            {
                GovernmentId = bulletin[0],
                Name = bulletin[1],
                Surname = bulletin[2],
                BirthDate = DateOnly.Parse(bulletin[3]),
                CandidateId = int.Parse(bulletin[4]),
            };
        }
    }
}
