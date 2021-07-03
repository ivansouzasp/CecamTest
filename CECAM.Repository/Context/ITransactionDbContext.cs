using System;
using System.Threading.Tasks;
using CECAM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CECAM.Repository.Context
{
    public interface ITransactionDbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        Task<int> SaveChanges();
    }
}
