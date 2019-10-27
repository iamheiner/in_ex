using Applicaction.Core;
using Applicaction.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace CatalogApp
{
    internal static class Startup
    {
        internal static void ConfigureHostConfiguration(IConfigurationBuilder config)
        {

        }
        internal static void ConfigureAppConfiguration(HostBuilderContext hostingContext, IConfigurationBuilder config)
        {
            config.SetBasePath(Directory.GetCurrentDirectory());
            config.AddJsonFile(Constants.CONFIGURATION_FILE, true);

            var args = Environment.GetCommandLineArgs();
            if (args != null) config.AddCommandLine(args);
        }
        internal static void ConfigureLogging(HostBuilderContext hostingContext, ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.AddConfiguration(hostingContext.Configuration);
        }

        /// <summary>
        /// Configuracion de servicios
        /// </summary>
        /// <param name="hostingContext"></param>
        /// <param name="services"></param>
        internal static void ConfigureServices(HostBuilderContext hostingContext, IServiceCollection services)
        {
            services.AddServices();

            // Servicio que se ejecuta al inicializar la aplicación.
            services.AddHostedService<CatalogHostedService>();
        }
    }
}
