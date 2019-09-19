using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelBoard.Data.Entities
{
  public  class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
