using Applicaction.Services.Catalog;
using Applicaction.Services.Common;
using Applicaction.Services.Customer;
using Applicaction.Services.Files;
using Applicaction.Services.RandomNumbers;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Applicaction.Services
{
    /// <summary>
    /// Inyección de servicios
    /// </summary>
    public static class ServicesDI
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IFile, FileService>();
            services.AddSingleton<IRandomNumbers, RandomNumbersServices>();
            services.AddSingleton<ICommon, CommonService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICatalog, CatalogService>();


            services.AddInfrastructureData();
        }
    }
}
