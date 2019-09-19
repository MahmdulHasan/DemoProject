using Microsoft.EntityFrameworkCore;
using PanelBoard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data
{
    public class PanelDbContext
        : DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public PanelDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString, b => b.MigrationsAssembly(_migrationAssemblyName));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Student>()
                .HasMany(sc => sc.StudentCourses)
                .WithOne(s => s.Student)
                .HasForeignKey(sk => sk.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(sc => sc.StudentCourses)
                .WithOne(c => c.Course)
                .HasForeignKey(cf => cf.CourseId);


            modelBuilder.Entity<TeacherStudent>()
               .HasKey(ts => new { ts.StudentId, ts.TeacherId });

            modelBuilder.Entity<Student>()
                .HasMany(ts => ts.TeacherStudents)
                .WithOne(s => s.Student)
                .HasForeignKey(sk => sk.StudentId);

            modelBuilder.Entity<Teacher>()
                .HasMany(ts => ts.TeacherStudents)
                .WithOne(t => t.Teacher)
                .HasForeignKey(tf => tf.TeacherId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Property> Properties { get; set; }

    }
}
