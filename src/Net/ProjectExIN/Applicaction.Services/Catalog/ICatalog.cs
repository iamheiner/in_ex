namespace Applicaction.Services.Catalog
{
    /// <summary>
    /// Interface ICatalog
    /// </summary>
    public interface ICatalog
    {
        /// <summary>
        /// Leer de los ficheros la información correspondientes a categorías y productos
        /// </summary>
        /// <returns></returns>
        ICatalog GetCatalog();
        /// <summary>
        /// Guardar fichero en formato Json
        /// </summary>
        /// <returns></returns>
        string SaveCatalogToJson();
        /// <summary>
        /// Guardar fichero en formato Xml
        /// </summary>
        /// <returns></returns>
        string SaveCatalogToXml();
    }
}
