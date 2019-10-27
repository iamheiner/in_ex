using Applicaction.Core;
using Infrastructure.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                                           .ConfigureHostConfiguration(Startup.ConfigureHostConfiguration)
                                           .ConfigureAppConfiguration(Startup.ConfigureAppConfiguration)
                                           .ConfigureLogging(Startup.ConfigureLogging)
                                           .ConfigureServices(Startup.ConfigureServices);

            await builder.RunConsoleAsync();
        }
    }
}
