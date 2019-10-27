using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace CatalogApp
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
