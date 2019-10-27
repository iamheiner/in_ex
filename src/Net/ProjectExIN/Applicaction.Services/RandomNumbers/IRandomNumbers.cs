using System;
using System.Collections.Generic;
using System.Text;

namespace Applicaction.Services.RandomNumbers
{
    /// <summary>
    /// Interface IRandomNumbers
    /// </summary>
    public interface IRandomNumbers
    {
        /// <summary>
        /// Genera números aleatorios
        /// </summary>
        /// <param name="totalNumeros">Cantidad de números a generar</param>
        /// <returns></returns>
        List<int> GenerarNumerosAleatorios(int totalNumeros);
    }
}
