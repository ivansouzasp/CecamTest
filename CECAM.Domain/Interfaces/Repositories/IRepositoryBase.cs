using System.Collections.Generic;
using System.Threading.Tasks;
using CECAM.Entities;

namespace CECAM.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {

        Task<int> Insert(Cliente cliente);
        Task<int> Update(Cliente cliente);
        Task<int> Delete(int id);
        Task<IEnumerable<T>> FetchAll();
        Task<T> FetchById(int id);
    }
}
