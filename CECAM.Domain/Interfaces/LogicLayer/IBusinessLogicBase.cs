using System.Collections.Generic;
using System.Threading.Tasks;
using CECAM.Entities;

namespace CECAM.Domain.Interfaces.LogicLayer
{
    public interface IBusinessLogicBase<T> where T : class
    {
        Task<int> Add(Cliente cliente);
        Task<int> Update(Cliente cliente);
        Task<int> Remove(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
