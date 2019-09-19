using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.UnitOfWork
{
    public abstract class UnitOfWork<T>
              : IDisposable where T : DbContext
    {

        protected DbContext _DbContext;
        public UnitOfWork(string connectionString, string migrationAssemblyName)
        {
            _DbContext = (DbContext)Activator.CreateInstance(typeof(T), connectionString, migrationAssemblyName);
        }

        public void Save()
        {
            _DbContext.SaveChanges();
        }
        public void Dispose()
        {
            _DbContext.Dispose();
        }
    }
}
