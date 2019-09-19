using PanelBoard.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.UnitOfWork
{
    public class TeacherUnitOfWork
            : UnitOfWork<PanelDbContext>
    {
        public StudentRepository StudentRepository;
        public TeacherRepository CourseRepository;
        public TeacherUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            StudentRepository = new StudentRepository(_DbContext);
            CourseRepository = new  TeacherRepository(_DbContext);
        }
    }
}
