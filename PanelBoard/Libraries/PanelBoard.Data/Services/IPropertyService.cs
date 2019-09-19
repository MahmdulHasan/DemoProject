using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Services
{
    using Data.Entities;
    public interface IPropertyService
    {
        void AddCustom(Property model);
    }
}
