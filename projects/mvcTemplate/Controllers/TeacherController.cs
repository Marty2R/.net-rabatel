using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        // GET: EventController

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var Teachers = _context.Teacher.ToList();
            return View(Teachers);
        }

        public ActionResult Add()
        {
            return View("~/Views/Teacher/AddTeacher.cshtml");
        }

        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Teacher object is null.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Teacher.Add(teacher);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
