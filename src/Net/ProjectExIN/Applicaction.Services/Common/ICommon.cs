using System;
using System.Collections.Generic;
using System.Text;

namespace Applicaction.Services.Common
{
    /// <summary>
    /// Interface ICommon
    /// </summary>
    public interface ICommon
    {
        /// <summary>
        /// Retorna la ruta de un fichero
        /// </summary>
        /// <param name="nameFile">Nombre del fichero</param>
        /// <returns></returns>
        string GetPathFile(string nameFile);
    }
}
