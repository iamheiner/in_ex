using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.UWO
{
    /// <summary>
    /// Interface IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        ICustomer Customer { get; }
    }
}
