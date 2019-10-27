using Applicaction.Services.Customer;
using Applicaction.Services.Files;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomersApp
{
    /// <summary>
    /// Servicio que se inicializa cuando arranca la aplicación
    /// </summary>
    internal class CustomersHostedService : IHostedService, IDisposable
    {
        private readonly ICustomerService customerService;
        public CustomersHostedService(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public void Dispose()
        {

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {                
                ReadCustomerts();
                
                SaveCustomers();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido completar el proceso, por favor vuelve a intentarlo.\n");
            }            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Leer el fichero con la información sobre los customers.
        /// </summary>
        void ReadCustomerts()
        {
            try
            {
                Console.WriteLine("Leyendo Customers....\n");
                this.customerService.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer los Customers.\n");
                throw ex;
            }
        }

        /// <summary>
        /// Almacenar en la base de datos la información con los customers.
        /// </summary>
        async void SaveCustomers()
        {
            try
            {
                Console.WriteLine("Guardando Customers....\n");
                await this.customerService.Save();
                Console.WriteLine("Customers guardados correctamente....\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar los Customers.\n");
                throw ex;
            }
        }
    }
}
