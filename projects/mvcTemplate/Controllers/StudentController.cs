using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{

    public class StudentController : Controller
    {
        // champ prive pour stocker le dbcontext
        private readonly ApplicationDbContext _context;
        // GET: StudentController
        // Creation d'une liste statique de Student

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }


        public ActionResult Add()
        {
            return View("~/Views/Student/Add.cshtml");
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            // Declencher le mecanisme de validation
            if (!ModelState.IsValid)
            {
                return View();
            }
            // Ajouter le teacher
            _context.Students.Add(student);

            // Sauvegarder les changements
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var studentToDelete = _context.Students.FirstOrDefault(s => s.Id == id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult StudentDetail(int id)
        {
            var studentDetail = _context.Students.FirstOrDefault(s => s.Id == id);
            return View("~/Views/DetailStudent/index.cshtml", studentDetail);
        }

        public ActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

    }
}