using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CECAM.Entities;
using CECAM.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CECAM.Repository.Commands
{
    public class GetAllClientesCommand: IRequest<IEnumerable<Cliente>>
    {
        public GetAllClientesCommand()
        {
        }

        public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesCommand, IEnumerable<Cliente>>
        {
            private readonly ITransactionDbContext _context;

            public GetAllClientesQueryHandler(ITransactionDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Cliente>> Handle(GetAllClientesCommand request, CancellationToken cancellationToken)
            {
                var clienteList = await _context.Clientes.ToListAsync();
                if (clienteList == null)
                {
                    return null;
                }
                return clienteList.AsReadOnly();
            }
        }
    }
}
