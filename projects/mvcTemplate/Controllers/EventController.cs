using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{

    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        // GET: EventController

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() // Affiche la vue Event
        {
            var Events = _context.Event.ToList();
            return View("~/Views/Event/Event.cshtml", Events);
        }

        public IActionResult Delete(string id) // supprime l'événement de la base de données
        {
            var eventItem = _context.Event.Find(int.Parse(id));
            if (eventItem != null)
            {
                _context.Event.Remove(eventItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddEvent() // Affiche la vue pour ajouter un événement
        {
            return View("~/Views/Event/AddEvent.cshtml");
        }

        [HttpPost]
        public IActionResult AddEvent(Event eventItem) // Ajoute un événement en base de données
        {
            if (eventItem == null)
            {
                return BadRequest("Event object is null.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Event.Add(eventItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}