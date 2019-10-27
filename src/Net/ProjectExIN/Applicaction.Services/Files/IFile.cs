using System;
using System.Collections.Generic;
using System.Text;

namespace Applicaction.Services.Files
{
    /// <summary>
    /// Interface IFile
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// Guarda fichero de números aleatorios
        /// </summary>
        /// <param name="totalNumbers"></param>
        /// <returns></returns>
        string SaveFileWithNumbers(List<int> totalNumbers);
    }
}
