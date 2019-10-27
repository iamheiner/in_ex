using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    /// <summary>
    /// Repositorio Customers, contiene métodos para el tratamiento de customers relacionados con la base de datos.
    /// </summary>
    public class CustomersRepository: ICustomer
    {
        private readonly DbContext dbContext;
        private DbSet<Customers> entity;
        public CustomersRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            entity = this.dbContext.Set<Customers>();
        }

        async Task ICustomer.AddAll(List<Customers> customers)
        {
            if (!entity.Any() && customers.Any())
            {
                await entity.AddRangeAsync(customers);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
