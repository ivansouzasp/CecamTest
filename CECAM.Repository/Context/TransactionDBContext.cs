using System.Threading.Tasks;
using CECAM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CECAM.Repository.Context
{
    public class TransactionDBContext : DbContext, ITransactionDbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public TransactionDBContext(DbContextOptions<TransactionDBContext> options) : base(options)
        {
        }

        public async Task<int> SaveChanges()
        {
           return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Cliente>(
                    c =>
                    {
                        c.HasKey("Codigo");
                        c.Property(v => v.RazaoSocial).HasColumnName("RazaoSocial").IsRequired(true);
                        c.Property(v => v.CNPJ).HasColumnName("CNPJ").IsRequired(true);
                        c.Property(v => v.DataCadastro).HasColumnName("DataCadastro");
                    });
        }
    }
}
