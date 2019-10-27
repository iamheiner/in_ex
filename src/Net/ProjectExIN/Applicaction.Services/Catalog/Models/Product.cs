using System;
using System.Collections.Generic;
using System.Text;

namespace Applicaction.Services.Catalog.Models
{
    public class Product
    {
        public int CategoryId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
