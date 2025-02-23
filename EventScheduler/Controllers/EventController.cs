using System.Reflection.Metadata.Ecma335;
using AspNetCoreGeneratedDocument;
using EventScheduler.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventScheduler.Controllers
{
  //  [Authorize] // Protects all actions with JWT authentication
    public class EventController : Controller
    {   
        private readonly IEvent _event;
        private readonly IEventRegistration _eventRegistration;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventController(IEvent __event, UserManager<ApplicationUser> userManager, IEventRegistration eventRegistration) { 
            _event = __event;
            _userManager = userManager;
            _eventRegistration = eventRegistration;
        }
        public IActionResult Index()
        {
            List<Event> EventList= _event.GetEvents().ToList();
            return View(EventList);
        }
        [Authorize]
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
        [HttpPost]
        public async Task<IActionResult> Register(int eventId)
        {
            var _userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(_userId))
            {
                return RedirectToAction("Login", "Auth");
            }
            await _eventRegistration.RegisterForEventAsync(_userId, eventId);
            return RedirectToAction("Index");
            
        }
        [Authorize]
        public async Task<IActionResult> MyEvents()
        {
            var userId = _userManager.GetUserId(User);
            var registeredEvents = await _eventRegistration.GetUserRegisteredEventsAsync(userId);

            return View(registeredEvents);
        }
    }
}
