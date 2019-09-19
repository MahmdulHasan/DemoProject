using Microsoft.EntityFrameworkCore;
using PanelBoard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBoard.Data.Repository
{
    public class StudentRepository
      : Repository<StudentCourse>
    {
        public StudentRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
        public IEnumerable<StudentCourse> GetIndividualStudentCourse(int id)
        {
               
                return _dbSet.Where(w => w.StudentId == id).Include(c => c.Course);
        }
                
    }
}


