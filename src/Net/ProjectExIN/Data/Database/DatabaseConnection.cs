using Applicaction.Core;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infrastructure.Data.Database
{
    /// <summary>
    /// DbContext para conexión a base de datos
    /// </summary>
    public class DatabaseConnection : DbContext
    {
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options) : base(options) { }

        public DbSet<Customers> Customers { get; set; }
    }

    /// <summary>
    /// DbFactory para el tratamiento en tiempo de diseño de la base de datos (Migraciones utilizando Code First).
    /// </summary>
    public class DBFactory : IDesignTimeDbContextFactory<DatabaseConnection>
    {
        public DatabaseConnection CreateDbContext(string[] args = null)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"{@Directory.GetCurrentDirectory()}/../CustomersApp/{Constants.CONFIGURATION_FILE}")
                .Build();

            var builder = new DbContextOptionsBuilder<DatabaseConnection>();
            var connectionString = configuration.GetConnectionString(Constants.NAME_CONNECTION_BBDD);

            if (!String.IsNullOrEmpty(connectionString))
            {
                builder.UseSqlServer(connectionString);
                var context = new DatabaseConnection(builder.Options);
                return context;
            }
            return null;
        }
    }
}
