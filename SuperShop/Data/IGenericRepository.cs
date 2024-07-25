using SuperShop.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsAsync(int id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> ExistsAsync(int id);
    }
}
