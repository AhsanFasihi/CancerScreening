using CancerScreening.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CancerScreening.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> ListAsync();
    }

    public interface ICancerAssessmentRepository : IRepository<CancerAssessment>
    {
        Task<IEnumerable<CancerAssessment>> ListByUserIdAsync(string userId);
    }

    public interface ICancerQuestionRepository : IRepository<CancerQuestion>
    {
        Task<IEnumerable<CancerQuestion>> ListByCancerTypeAsync(string cancerType);
    }
}
