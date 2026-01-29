using CancerScreening.Domain.Entities;
using CancerScreening.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerScreening.Infrastructure.Repositories
{
    public class CancerAssessmentRepository : ICancerAssessmentRepository
    {
        private readonly List<CancerAssessment> _store = new();
        private int _idCounter = 1;

        public Task<CancerAssessment> AddAsync(CancerAssessment entity)
        {
            entity.Id = _idCounter++;
            _store.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<CancerAssessment>> ListAsync() => Task.FromResult<IEnumerable<CancerAssessment>>(_store);

        public Task<IEnumerable<CancerAssessment>> ListByUserIdAsync(string userId)
        {
            var list = _store.Where(a => a.UserId == userId);
            return Task.FromResult<IEnumerable<CancerAssessment>>(list);
        }
    }
}
