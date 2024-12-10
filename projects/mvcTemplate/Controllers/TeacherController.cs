using Microsoft.AspNetCore.Mvc;

using mvc.Models;

namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        // GET: TeacherController
        // Creation d'une liste statique de Student
        private static List<Teacher> teacher = new()
        {
            new() { Id = 1, FirstName = "John", LastName = "Doe", Age = 35, Salary = 75000, Subject = "Mathematics", HireDate = new DateTime(2020, 8, 15) },
            new() { Id = 2, FirstName = "Jane", LastName = "Smith", Age = 42, Salary = 82000, Subject = "Physics", HireDate = new DateTime(2018, 9, 1) },
            new() { Id = 3, FirstName = "Robert", LastName = "Johnson", Age = 38, Salary = 78000, Subject = "Chemistry", HireDate = new DateTime(2019, 1, 10) },
            new() { Id = 4, FirstName = "Mary", LastName = "Williams", Age = 45, Salary = 85000, Subject = "Biology", HireDate = new DateTime(2017, 3, 20) },
        };
        public ActionResult Index()
        {
            return View(teacher);
        }

    }
}
