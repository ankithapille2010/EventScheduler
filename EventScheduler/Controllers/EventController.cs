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

    }
}
