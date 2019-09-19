using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Repository
{
    using Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class PropertyRepository
        : Repository<Property>
    {
        public PropertyRepository(DbContext context)
            : base(context)
        {

            

        }

        public void AddCustom()
        {

        }
    }
}
