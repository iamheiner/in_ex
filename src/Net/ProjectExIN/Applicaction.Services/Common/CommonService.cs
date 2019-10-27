using Applicaction.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Applicaction.Services.Common
{
    /// <summary>
    /// Servicio Common, contiene los métodos comunes a todos los proyectos. 
    /// </summary>
    public class CommonService : ICommon
    {
        string GetNameFile(string typeFile)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                             .AddJsonFile(Constants.CONFIGURATION_FILE, optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            return configuration.GetSection($"Files:{typeFile}").Value;
        }

        string ICommon.GetPathFile(string nameFile)
        {
            return $"{Directory.GetCurrentDirectory()}\\{GetNameFile(nameFile)}";
        }
    }
}
