﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Entities
{
  public  class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
