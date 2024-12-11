using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{

    public class StudentController : Controller
    {
        private readonly UserManager<Student> _userManager;

        // GET: StudentController
        // Creation d'une liste statique de Student

        public StudentController(UserManager<Student> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Register()
        {
            return View("~/Views/Auth/Register.cshtml");
        }


        public ActionResult Add()
        {
            return View("~/Views/Student/Add.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            if (student == null)
            {
                return BadRequest("Student object is null.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            // Assurez-vous que le UserName est défini
            student.UserName = student.Email;
            student.Age = 20;
            student.GPA = 0;
            student.Age = 2;

            var result = await _userManager.CreateAsync(student);
            if (!result.Succeeded)
            {
                // Gérez les erreurs de création ici
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(student);
            }

            return RedirectToAction("Index", "Student");
        }

        public ActionResult Delete(string id)
        {
            var student = _userManager.FindByIdAsync(id).Result;
            if (student != null)
            {
                _userManager.DeleteAsync(student).Wait();
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> StudentDetail(int id)
        {
            var student = await _userManager.FindByIdAsync(id.ToString());
            if (student != null)
            {
                Console.WriteLine("DATAS : " + student);
                return View("~/Views/DetailStudent/index.cshtml", student);
            }
            else
            {
                Console.WriteLine("ERROR");
                return NotFound();
            }
        }

        public ActionResult Index()
        {
            var students = _userManager.Users.ToList();
            return View(students);
        }

    }
}