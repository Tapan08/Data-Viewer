using StudentsApp.Entities;
using StudentsApp.Models;
using StudentsApp.Services;
using Microsoft.AspNetCore.Mvc;


namespace StudentsApp.Controllers
{

    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/students/{status?}")]


        public IActionResult Items(string status)
        {
           
            var students = (status == null || status.ToLower() == "all")
                           ? _studentService.GetAllStudents()
                           : _studentService.GetStudentsByStatus(status);


            var viewModel = new StudentsViewModel
            {
                Students = students,
                //TabNames = _studentService.GetAllStudents().ToArray(),
                Active = status ?? "All",
                New = new Student()
            };

            return View(viewModel);

        }

        [HttpPost("/students")]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(string Name, string EnrollmentStatus)
        {
            
            var newS = new Student
            {
                Name = Name,
                EnrollmentStatus = EnrollmentStatus
            };

            int newSID = _studentService.AddStudent(newS);

            return RedirectToAction("Items", new { status = EnrollmentStatus });







        }


    }
}
