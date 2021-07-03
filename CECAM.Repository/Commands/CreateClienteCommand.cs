using System.Threading;
using System.Threading.Tasks;
using CECAM.Entities;
using CECAM.Repository.Context;
using MediatR;

namespace CECAM.Repository.Commands
{
    public class CreateClienteCommand: IRequest<int>
    {
        public Cliente _cliente { get; set; }
        public CreateClienteCommand(Cliente cliente)
        {
            _cliente = cliente;
        }

        public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
        {
            private readonly ITransactionDbContext _context;

            public CreateClienteCommandHandler(ITransactionDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
            {
                await _context.Clientes.AddAsync(request._cliente);
                await _context.SaveChanges();
                return request._cliente.Codigo;
            }
        }
    }
}
