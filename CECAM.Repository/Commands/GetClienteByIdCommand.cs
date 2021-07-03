using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CECAM.Entities;
using CECAM.Repository.Context;
using MediatR;

namespace CECAM.Repository.Commands
{
    public class GetClienteByIdCommand: IRequest<Cliente>
    {
        public int Codigo { get; set; }

        public class GetClienteByIdCommandHandler: IRequestHandler<GetClienteByIdCommand, Cliente>
        {
            private readonly ITransactionDbContext _context;
            public GetClienteByIdCommandHandler(ITransactionDbContext context)
            {
                _context = context;
            }

            public async Task<Cliente> Handle(GetClienteByIdCommand request, CancellationToken cancellationToken)
            {
                var cliente = _context.Clientes.Where(a => a.Codigo == ((GetClienteByIdCommand)request).Codigo).FirstOrDefault();
                if (cliente == null) return null;
                return cliente;
            }
        }

    }
}
