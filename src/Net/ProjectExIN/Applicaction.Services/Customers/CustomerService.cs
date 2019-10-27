using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applicaction.Core;
using Applicaction.Services.Common;
using Applicaction.Services.Customer.DTO;
using Entities;
using Infrastructure.Data.UWO;
using TinyCsvParser;

namespace Applicaction.Services.Customer
{
    /// <summary>
    /// Servicio que contiene todos los métodos relacionados con Customers
    /// </summary>
    public class CustomerService : ICustomerService
    {
        List<Customers> CustomersList = new List<Customers>();
        private readonly IUnitOfWork unitOfWork;
        private readonly ICommon common;
        public CustomerService(IUnitOfWork unitOfWork, ICommon common)
        {
            this.unitOfWork = unitOfWork;
            this.common = common;
        }
        ICustomerService ICustomerService.Read()
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ';');
            CustomerCSVMapping csvMapper = new CustomerCSVMapping();
            CsvParser<Customers> csvParser = new CsvParser<Customers>(csvParserOptions, csvMapper);

            var result = csvParser
               .ReadFromFile(this.common.GetPathFile(Constants.NAME_FILE_CUSTOMERS), Encoding.UTF8)
               .ToList();

            CustomersList = result.Where(m=> m.Error == null).Select(m => m.Result).ToList();
            return this;
        }
        async Task ICustomerService.Save()
        {
            await this.unitOfWork.Customer.AddAll(CustomersList);
        }
    }
}
