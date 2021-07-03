using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CECAM.Entities;
using CECAM.Repository.Context;
using MediatR;

namespace CECAM.Repository.Commands
{
    public class UpdateClienteCommand: IRequest<int>
    {
        public Cliente _cliente;
        public UpdateClienteCommand(Cliente cliente)
        {
            _cliente = cliente;
        }

        public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, int>
        {
            private readonly ITransactionDbContext _context;
            public UpdateClienteCommandHandler(ITransactionDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
            {
                var cliente = _context.Clientes.Where(a => a.Codigo == request._cliente.Codigo).FirstOrDefault();
                if (cliente == null)
                {
                    return default;
                }
                else
                {
                    cliente.Codigo = request._cliente.Codigo;
                    cliente.RazaoSocial = request._cliente.RazaoSocial;
                    cliente.CNPJ = request._cliente.CNPJ;
                    cliente.DataCadastro = request._cliente.DataCadastro;
                    //_context.Clientes.Update(((UpdateClienteCommand)request)._cliente);
                    //_context.Clientes.Update(cliente);
                    await _context.SaveChanges();
                }
                return cliente.Codigo;
            }
        }
    }
}
