using CECAM.Domain.Interfaces.Repositories;
using CECAM.Repository.Context;
using CECAM.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CECAM.IOC.DependencyInjection
{
    public class ConfigureRepositories
    {
        public static void ConfigureDependenciesRepositories(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<TransactionDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(TransactionDBContext).Assembly.FullName)));
            serviceCollection.AddScoped<ITransactionDbContext>(provider => provider.GetService<TransactionDBContext>());
            serviceCollection.AddTransient(typeof(IClienteRepository), typeof(ClienteRepository));
        }
    }
}
