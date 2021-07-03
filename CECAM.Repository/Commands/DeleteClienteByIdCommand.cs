using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CECAM.Repository.Context;
using MediatR;

namespace CECAM.Repository.Commands
{
    public class DeleteClienteByIdCommand: IRequest<int>
    {
        public int Codigo { get; set; }

        public class DeleteClienteByIdCommandHandler: IRequestHandler<DeleteClienteByIdCommand, int>
        {
            private readonly ITransactionDbContext _context;
            public DeleteClienteByIdCommandHandler(ITransactionDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteClienteByIdCommand request, CancellationToken cancellationToken)
            {
                var cliente = _context.Clientes.Where(a => a.Codigo == request.Codigo).FirstOrDefault();
                if (cliente == null) return default;
                _context.Clientes.Remove(cliente);
                await _context.SaveChanges();
                return cliente.Codigo;
            }
        }
    }
}
