using EventScheduler.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventScheduler.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;


        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           var events = _context.Events.ToList();
           return View(events);
        }
        [HttpPost]
        public IActionResult Create(Event ev)
        {
            if (!ModelState.IsValid)
            {
                return View(ev); // Return the form with validation errors
            }

            _context.Events.Add(ev);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View(); // This will render the Create view when accessed via GET
        }
        public IActionResult Edit(int id)
        {
            var eventItem = _context.Events.Find(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View(eventItem);
        }

        [HttpPost]
        public IActionResult Edit(Event ev)
        {
            if (!ModelState.IsValid)
            {
                return View(ev);
            }

            _context.Events.Update(ev);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var eventItem = _context.Events.Find(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
