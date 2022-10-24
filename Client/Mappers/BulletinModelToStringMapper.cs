using Shared.Mappers;
using Shared.Models;

namespace Client.Mappers
{
    public class BulletinModelToStringMapper : IMapper<BulletinModel, string>
    {
        public string Map(BulletinModel entity)
        {
            return string.Join("|", entity.GovernmentId, entity.Name, entity.Surname, 
                entity.BirthDate, entity.CandidateId);
        }
    }
}
