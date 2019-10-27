using Applicaction.Services.Catalog;
using Applicaction.Services.Files;
using Applicaction.Services.RandomNumbers;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogApp
{
    /// <summary>
    /// Servicio que se inicializa cuando arranca la aplicación
    /// </summary>
    internal class CatalogHostedService : IHostedService, IDisposable
    {
        private readonly ICatalog  catalog;
        public CatalogHostedService(ICatalog catalog)
        {
            this.catalog = catalog;
        }
        public void Dispose()
        {
           
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            GenerateCatalog();
            SaveJson();
            SaveXml();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        void GenerateCatalog()
        {
            try
            {
                this.catalog.GetCatalog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer los ficheros, por favor vuelve a intentarlo.\n");
                GenerateCatalog();
            }
        }

        void SaveJson()
        {
            try
            {             
                Console.WriteLine($"Catalog json generado correctamente, se encuentra en la dirección:\n {this.catalog.SaveCatalogToJson()} .\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el catalog json, por favor vuelve a intentarlo.\n");
            }
        }

        void SaveXml()
        {
            try
            {
                Console.WriteLine($"Catalog xml generado correctamente, se encuentra en la dirección:\n {this.catalog.SaveCatalogToXml()} .\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el catalog xml, por favor vuelve a intentarlo.\n");
            }
        }

    }
}
