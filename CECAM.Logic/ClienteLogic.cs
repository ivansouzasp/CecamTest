using System;
using CECAM.Domain.Interfaces.LogicLayer;
using CECAM.Domain.Interfaces.Repositories;
using CECAM.Entities;

namespace CECAM.Logic
{
    public class ClienteLogic: BusinessLogicBase<Cliente>, IClienteLogic
    {
        public ClienteLogic(IClienteRepository clienteRepository): base(clienteRepository)
        {
        }
    }
}
