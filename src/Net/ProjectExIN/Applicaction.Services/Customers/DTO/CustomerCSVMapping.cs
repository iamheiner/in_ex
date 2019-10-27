using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace Applicaction.Services.Customer.DTO
{
    public class CustomerCSVMapping : CsvMapping<Customers>
    {
        public CustomerCSVMapping()
            : base()
        {
            MapProperty(0, x => x.Id);
            MapProperty(1, x => x.Name);
            MapProperty(2, x => x.Address);
            MapProperty(3, x => x.City);
            MapProperty(4, x => x.Country);
            MapProperty(5, x => x.PostalCode);
            MapProperty(6, x => x.Phone);
        }
    }
}
