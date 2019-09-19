using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBoard.Data.UnitOfWork;
namespace PanelBoard.Web.Controllers
{
    using Data.Entities;
    public class StudentController : Controller
    {

        private readonly StudentUnitOfWork _studentUnitOfWork;
        public StudentController(StudentUnitOfWork studentUnitOfWork)
        {
            _studentUnitOfWork = studentUnitOfWork;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddStudent()
        {
            var course = new Course() { Name = "Database Design" };
            var student = new Student() { Name = "Mahmudul Hasan" };

            var studentCourse = new StudentCourse() { Student = student, Course = course };

            _studentUnitOfWork.StudentRepository.Add(studentCourse);

            _studentUnitOfWork.Save();


            return View();
        }

        public IActionResult GetStudentCourse()
        {
          
            return View();
        }

        public IActionResult GetCourse()
        {
            var student = _studentUnitOfWork.StudentRepository.GetIndividualStudentCourse(1);

            var course = student.Select(s => new SCourses {
                 Name = s.Course.Name
            });

            return Json(new { data = course });
        }
    }

    public class SCourses
    {
        public string Name { get; set; }
    }
}