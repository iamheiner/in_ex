using Applicaction.Core;
using Infrastructure.Data.Database;
using Infrastructure.Data.UWO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Infrastructure.Data
{
    // Inyección de servicios relacionados con Infrastructure.Data
    public static class InfrastructureDataDI
    {
        public static void AddInfrastructureData(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                           .AddJsonFile(Constants.CONFIGURATION_FILE, optional: true, reloadOnChange: true).Build();

            services.AddDbContext<DatabaseConnection>(options =>
            options.UseSqlServer(builder.GetConnectionString(Constants.NAME_CONNECTION_BBDD)));
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
