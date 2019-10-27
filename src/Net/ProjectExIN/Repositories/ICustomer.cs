using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    /// <summary>
    /// Interfaces ICustomer
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// Guardar una lista de Customers en base de datos
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        Task AddAll(List<Customers> customers);
    }
}
