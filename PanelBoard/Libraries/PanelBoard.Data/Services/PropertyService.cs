using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Services
{
    using Data.Entities;
    using Data.UnitOfWork;
   public class PropertyService
        : IPropertyService
    {
        public PropertyUnitOfWork PropertyUnitOfWork; 
        public PropertyService(PropertyUnitOfWork service)
        {
            PropertyUnitOfWork = service;

        }

        public void AddCustom(Property model)
        {
            PropertyUnitOfWork.PropertyRepository.Add(model);
        }

        public void Save()
        {
            PropertyUnitOfWork.Save();
        }
    }
}
