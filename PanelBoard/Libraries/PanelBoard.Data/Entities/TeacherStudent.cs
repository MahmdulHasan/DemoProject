using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Entities
{
   public class TeacherStudent
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
             
    }
}
