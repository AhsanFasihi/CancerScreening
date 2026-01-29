using CancerScreening.Domain.Entities;
using CancerScreening.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerScreening.Infrastructure.Repositories
{
    public class CancerQuestionRepository : ICancerQuestionRepository
    {
        private readonly List<CancerQuestion> _store = new();
        private int _idCounter = 1;

        public Task<CancerQuestion> AddAsync(CancerQuestion entity)
        {
            entity.Id = _idCounter++;
            _store.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<CancerQuestion>> ListAsync() => Task.FromResult<IEnumerable<CancerQuestion>>(_store);

        public Task<IEnumerable<CancerQuestion>> ListByCancerTypeAsync(string cancerType)
        {
            var list = _store.Where(q => q.CancerType == cancerType);
            return Task.FromResult<IEnumerable<CancerQuestion>>(list);
        }
    }
}
