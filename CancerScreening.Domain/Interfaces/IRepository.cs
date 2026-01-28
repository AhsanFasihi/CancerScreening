using System.Collections.Generic;
using System.Threading.Tasks;

namespace CancerScreening.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> ListAsync();
    }
}
