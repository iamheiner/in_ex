using Applicaction.Services.Files;
using Applicaction.Services.RandomNumbers;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RandomApp
{
    /// <summary>
    /// Servicio que se inicializa cuando arranca la aplicación
    /// </summary>
    internal class RandomHostedService : IHostedService, IDisposable
    {
        private readonly IRandomNumbers randomNumbers;
        private readonly IFile file;
        public RandomHostedService(IRandomNumbers randomNumbers, IFile file)
        {
            this.randomNumbers = randomNumbers;
            this.file = file;
        }
        public void Dispose()
        {

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            GetTotalNumbers();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        void GetTotalNumbers()
        {
            try
            {
                Console.Write("Introduce la cantidad de números aleatorios a generar: ");
                int totalNumbers;

                string totalNumbersStr = Console.ReadLine();
                if (!int.TryParse(totalNumbersStr, out totalNumbers))
                {
                    throw new Exception();
                }
                List<int> numbers = this.randomNumbers.GenerarNumerosAleatorios(totalNumbers);
                string path = this.file.SaveFileWithNumbers(numbers);
                Console.WriteLine($"El fichero se ha generado correctamente en la siguiente dirección:\n {path}\n");
            }
            catch (Exception)
            {
                Console.WriteLine("Error al generar el fichero, por favor vuelve a intentarlo.\n");
                GetTotalNumbers();
            }
        }
    }
}
