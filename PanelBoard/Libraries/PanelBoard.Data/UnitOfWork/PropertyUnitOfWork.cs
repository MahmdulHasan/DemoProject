using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.UnitOfWork
{
    using PanelBoard.Data.Repository;

    public class PropertyUnitOfWork
        : UnitOfWork<PanelDbContext>
    {
        public readonly PropertyRepository PropertyRepository;
        public PropertyUnitOfWork(string connectionString, string migrationAssemblyName)
           : base(connectionString, migrationAssemblyName)
        {
             PropertyRepository = new PropertyRepository(_DbContext);
        }
    }
}
