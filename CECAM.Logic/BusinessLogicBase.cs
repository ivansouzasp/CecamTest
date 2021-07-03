using System.Collections.Generic;
using System.Threading.Tasks;
using CECAM.Domain.Interfaces.LogicLayer;
using CECAM.Domain.Interfaces.Repositories;
using CECAM.Entities;

namespace CECAM.Logic
{
    public class BusinessLogicBase<T> : IBusinessLogicBase<T> where T : class
    {
        protected IRepositoryBase<T> _repository;
        public BusinessLogicBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(Cliente cliente)
        {
            return await _repository.Insert(cliente);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.FetchAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.FetchById(id);
        }

        public async Task<int> Remove(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<int> Update(Cliente cliente)
        {
            return await _repository.Update(cliente);
        }
    }
}
