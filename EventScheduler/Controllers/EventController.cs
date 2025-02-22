using System.Reflection.Metadata.Ecma335;
using AspNetCoreGeneratedDocument;
using EventScheduler.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventScheduler.Controllers
{
    public class EventController : Controller
    {   
        private readonly IEvent _event;
        public EventController(IEvent __event) { 
            _event = __event;
        }
        public IActionResult Index()
        {
            List<Event> EventList= _event.GetEvents().ToList();
            return View(EventList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Event ev)
        {
            if (!ModelState.IsValid)
                return View();
            _event.CreateEvent(ev);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) { 
            var ev = _event.GetEvent(id);
            return View(ev);
        }
        [HttpPost]
        public IActionResult Edit(Event ev)
        {
            if (!ModelState.IsValid) {
                return View(ev);
            }
            _event.EditEvent(ev);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _event.DeleteEvent(id);
            return RedirectToAction("Index");
        }

    }
}
