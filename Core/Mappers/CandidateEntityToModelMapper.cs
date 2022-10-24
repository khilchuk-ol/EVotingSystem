using Core.Entities;
using Shared.Mappers;
using Shared.Models;

namespace Core.Mappers
{
    public class CandidateEntityToModelMapper : IMapper<Candidate, CandidateModel>
    {
        public CandidateModel Map(Candidate entity)
        {
            return new CandidateModel()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}
