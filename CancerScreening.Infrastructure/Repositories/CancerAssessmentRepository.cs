using CancerScreening.Domain.Entities;
using CancerScreening.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancerScreening.Infrastructure.Repositories
{
    public class CancerAssessmentRepository : IRepository<CancerAssessment>
    {
        private readonly List<CancerAssessment> _store = new();
        public Task<CancerAssessment> AddAsync(CancerAssessment entity)
        {
            _store.Add(entity);
            return Task.FromResult(entity);
        }
        public Task<IEnumerable<CancerAssessment>> ListAsync() => Task.FromResult<IEnumerable<CancerAssessment>>(_store);
    }
}
