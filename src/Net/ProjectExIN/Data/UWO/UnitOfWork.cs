using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Data.Database;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Infrastructure.Data.UWO
{
    /// <summary>
    /// UnitOfWork es el punto de acceso a todos nuestros repositorios para el tratamiento de datos en BBDD.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseConnection databaseConnection;
        public UnitOfWork(DatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;

            // Se ejecutan todas las migraciones pendientes.
            this.databaseConnection.Database.MigrateAsync().Wait();
        }

        private ICustomer _Customer;
        ICustomer IUnitOfWork.Customer => this._Customer ?? (this._Customer = new CustomersRepository(this.databaseConnection));
    }
}
