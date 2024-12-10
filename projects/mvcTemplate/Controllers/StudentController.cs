using Microsoft.AspNetCore.Mvc;

using mvc.Models;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        // Creation d'une liste statique de Student
        private static List<Student> students = new()
        {
            new() { AdmissionDate = new DateTime(2022, 9, 1), Age = 19, FirstName = "Alice", GPA = 3.8, Id = 1, LastName = "Smith", Major = Major.CS },
            new() { AdmissionDate = new DateTime(2023, 1, 15), Age = 21, FirstName = "Bob", GPA = 3.2, Id = 2, LastName = "Johnson", Major = Major.IT },
            new() { AdmissionDate = new DateTime(2022, 8, 30), Age = 20, FirstName = "Emma", GPA = 3.9, Id = 3, LastName = "Williams", Major = Major.MATH },
            new() { AdmissionDate = new DateTime(2023, 10, 15), Age = 19, FirstName = "Sarah", GPA = 3.6, Id = 4, LastName = "Davis", Major = Major.OTHER },
            new() { AdmissionDate = new DateTime(2023, 11, 1), Age = 20, FirstName = "John", GPA = 3.1, Id = 5, LastName = "Miller", Major = Major.OTHER },
            new() { AdmissionDate = new DateTime(2023, 12, 1), Age = 21, FirstName = "Emily", GPA = 3.7, Id = 6, LastName = "Wilson", Major = Major.OTHER },
            new() { AdmissionDate = new DateTime(2024, 1, 1), Age = 22, FirstName = "William", GPA = 3.3, Id = 7, LastName = "Moore", Major = Major.OTHER },
            new() { AdmissionDate = new DateTime(2024, 2, 1), Age = 23, FirstName = "Olivia", GPA = 3.5, Id = 8, LastName = "Taylor", Major = Major.OTHER },
            new() { AdmissionDate = new DateTime(2023, 9, 1), Age = 18, FirstName = "Michael", GPA = 3.4, Id = 9, LastName = "Brown", Major = Major.OTHER },
        };

        public ActionResult Add()
        {
            return View("~/Views/Student/Add.cshtml");
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View("~/Views/Student/Add.cshtml", student);
        }

        public ActionResult Delete(int id)
        {
            var studentToDelete = students.FirstOrDefault(s => s.Id == id);
            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);
            }
            return RedirectToAction("Index");
        }

        public ActionResult StudentDetail(int id)
        {
            var studentDetail = students.FirstOrDefault(s => s.Id == id);
            return View("~/Views/DetailStudent/index.cshtml", studentDetail);
        }

        public ActionResult Index()
        {
            return View(students);
        }
    }
}