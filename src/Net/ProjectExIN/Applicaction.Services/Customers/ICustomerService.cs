using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Applicaction.Services.Customer
{
    /// <summary>
    /// Interface ICustomerService
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Lee el fichero que contiene la lista de Customers
        /// </summary>
        /// <returns></returns>
        ICustomerService Read();
        /// <summary>
        /// Guarda en base de datos la lista de Customers
        /// </summary>
        /// <param name="customers"></param>
        Task Save();
    }
}
