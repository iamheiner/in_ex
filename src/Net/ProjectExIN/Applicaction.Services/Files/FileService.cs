using Applicaction.Core;
using Applicaction.Services.Common;
using System.Collections.Generic;

namespace Applicaction.Services.Files
{
    /// <summary>
    /// Servicio File, contiene metodos para el tratamiento de archivos.
    /// </summary>
    public class FileService : IFile
    {
        private readonly ICommon common;
        public FileService(ICommon common)
        {
            this.common = common;
        }
        string IFile.SaveFileWithNumbers(List<int> totalNumbers)
        {
            string path = this.common.GetPathFile(Constants.NAME_FILE_WITH_NUMBERS);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.File.Create(this.common.GetPathFile(Constants.NAME_FILE_WITH_NUMBERS))))
            {
                foreach (var item in totalNumbers)
                {
                    file.WriteLine(item);
                }
            }
            return path;
        }
    }
}
