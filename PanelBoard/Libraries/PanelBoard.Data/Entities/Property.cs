using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelBoard.Data.Entities
{
   public class Property
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }


    }
}
