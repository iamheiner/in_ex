using Applicaction.Core;
using Applicaction.Services.Catalog.Models;
using Applicaction.Services.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Applicaction.Services.Catalog
{
    /// <summary>
    /// Servicio Catalog, contiene todos los métodos relacionados con el catalog
    /// </summary>
    public class CatalogService : ICatalog
    {
        List<Category> categories = new List<Category>();
        private readonly ICommon common;
        public CatalogService(ICommon common)
        {
            this.common = common;
        }
        ICatalog ICatalog.GetCatalog()
        {
            // Cargo la lista de productos
            var products = File.ReadAllLines(this.common.GetPathFile(Constants.NAME_FILE_PRODUCTS)).Select(a => a.Split(';')).Skip(1).Select(m => new Product
            {
                Id = Convert.ToInt32(m[0]),
                CategoryId = Convert.ToInt32(m[1]),
                Name = Convert.ToString(m[2]),
                Price = Convert.ToDouble(m[3])
            });

            // Cargo la lista de categorías y le asocio los productos que le corresponde a cada categoría.
            categories = File.ReadAllLines(this.common.GetPathFile(Constants.NAME_FILE_CATEGORIES)).Select(a => a.Split(';')).Skip(1).Select(m => new Category
            {
                Id = Convert.ToInt32(m[0]),
                Name = Convert.ToString(m[1]),
                Description = Convert.ToString(m[2]),
                Products = products.Where(k => k.CategoryId == Convert.ToInt32(m[0])).ToList()
            }).ToList();

            return this;
        }

        string ICatalog.SaveCatalogToJson()
        {
            string path = this.common.GetPathFile(Constants.NAME_FILE_CATALOG_JSON);
            File.WriteAllText(path, JsonConvert.SerializeObject(categories));
            return path;
        }

        string ICatalog.SaveCatalogToXml()
        {
            XNamespace ns = "http://schemas.datacontract.org/2004/07/Catalog";
            XDocument doc = new XDocument(
                new XElement(ns + "ArrayOfCategory", new XAttribute(XNamespace.Xmlns + "i", "http://www.w3.org/2001/XMLSchema-instance"),
                  this.categories.Select(m => new XElement("Category",
                                                                 new XElement("Description", m.Description),
                                                                 new XElement("Id", m.Id),
                                                                 new XElement("Name", m.Name),
                                                                 new XElement("Products",
                                                                   m.Products.Select(x => new XElement("Product",
                                                                   new XElement("CategoryId", x.CategoryId),
                                                                   new XElement("Id", x.Id),
                                                                   new XElement("Name", x.Name),
                                                                   new XElement("Price", x.Price)
                                                                   ))
                                                                 )
                                                      )))
                                      );

            // Elimino los namespaces vacíos
            foreach (var node in doc.Root.Descendants())
            {
                if (node.Name.NamespaceName == "")
                {
                    node.Attributes("xmlns").Remove();
                    node.Name = node.Parent.Name.Namespace + node.Name.LocalName;
                }
            }

            string path = this.common.GetPathFile(Constants.NAME_FILE_CATALOG_XML);
            doc.Save(path);
            return path;
        }
    }
}
