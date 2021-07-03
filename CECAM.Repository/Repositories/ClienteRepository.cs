using System.Collections.Generic;
using System.Threading.Tasks;
using CECAM.Domain.Interfaces.Repositories;
using CECAM.Entities;
using CECAM.Repository.Commands;
using MediatR;

namespace CECAM.Repository.Repositories
{
    public class ClienteRepository: IClienteRepository
    {
        private IMediator _mediator;
        public ClienteRepository(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<int> Delete(int id)
        {
            return await _mediator.Send(new DeleteClienteByIdCommand { Codigo = id });
        }

        public async Task<IEnumerable<Cliente>> FetchAll()
        {
            return await _mediator.Send(new GetAllClientesCommand());
        }

        public async Task<Cliente> FetchById(int id)
        {
            return await _mediator.Send(new GetClienteByIdCommand { Codigo = id });
        }

        public async Task<int> Insert(Cliente cliente)
        {
            var createCommand = new CreateClienteCommand(cliente);
            
            return await _mediator.Send(createCommand);
        }

        public async Task<int> Update(Cliente cliente)
        {
            var updateCommand = new UpdateClienteCommand(cliente);
            return await _mediator.Send(updateCommand);
        }
    }
}
