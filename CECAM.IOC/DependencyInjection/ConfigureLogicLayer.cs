using System;
using CECAM.Domain.Interfaces.LogicLayer;
using CECAM.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace CECAM.IOC.DependencyInjection
{
    public class ConfigureLogicLayer
    {
        public static void ConfigureDependenciesLogicLayer(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IClienteLogic), typeof(ClienteLogic));
        }
    }
}
