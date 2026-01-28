using CancerScreening.Domain.Entities;
using CancerScreening.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancerScreening.Infrastructure.Repositories
{
    public class CancerQuestionRepository : IRepository<CancerQuestion>
    {
        private readonly List<CancerQuestion> _questions = new()
        {
            new CancerQuestion { Id=1, CancerType="Breast", Text="Are you a female aged 40 or above?", Weight=1 },
            new CancerQuestion { Id=2, CancerType="Breast", Text="Do you have a first-degree relative with breast cancer?", Weight=2 }
        };

        public Task<CancerQuestion> AddAsync(CancerQuestion entity)
        {
            _questions.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<CancerQuestion>> ListAsync() => Task.FromResult<IEnumerable<CancerQuestion>>(_questions);
    }
}
