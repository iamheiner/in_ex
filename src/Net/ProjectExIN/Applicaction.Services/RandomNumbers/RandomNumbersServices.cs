using System;
using System.Collections.Generic;
using System.Linq;

namespace Applicaction.Services.RandomNumbers
{
    /// <summary>
    /// Servicio RandomNumbers
    /// </summary>
    public class RandomNumbersServices : IRandomNumbers
    {
        List<int> IRandomNumbers.GenerarNumerosAleatorios(int totalNumeros)
        {
            List<int> numerosRetorno = new List<int>();

            // Primero voy a generar una lista de números aleatorios con la cantidad solicitada por el usuario.
            while (numerosRetorno.Count() < totalNumeros)
            {
                Random random = new Random();
                // Genera un número aleatorio entre 0 e int.MaxValue
                int itemNumber = random.Next();
                numerosRetorno.Add(itemNumber);
            }

            // esta lista generada le elimino los números repetidos
            numerosRetorno = numerosRetorno.Distinct().ToList();

            // Este paso se ejecuta si la cantidad de números solicitados por el usuario es mayor que la cantidad que hay en la lista
            // con el condicionante que por cada número que se vaya a introducir se comprueba si ya existe en la lista.
            while (numerosRetorno.Count() < totalNumeros)
            {
                Random random = new Random();
                // Genera un número aleatorio entre 0 e int.MaxValue
                int itemNumber = random.Next();

                // Compruebo si el número generado se encuentra en la lista de números a retornar, 
                // ya que necesito números sin repetir.
                if (!numerosRetorno.Contains(itemNumber))
                {
                    numerosRetorno.Add(itemNumber);
                }
            }

            // Retorno de la lista de número ordenados de menor a mayor
            return numerosRetorno.OrderBy(m => m).ToList();
        }
    }
}
