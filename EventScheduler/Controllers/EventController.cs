using System.Reflection.Metadata.Ecma335;
using AspNetCoreGeneratedDocument;
using EventScheduler.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventScheduler.Controllers
{
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
           return View();
        }
        
        [Authorize]
        public IActionResult Create()
        {
           // Create a new Event instance and set TimeSlots
            var model = new Event
            {
                TimeSlots = GenerateTimeSlots() // Assign the generated time slots
            };
            return View(model);
        }
        //Generate all the timeslots for 15 minute interval 
        private List<string> GenerateTimeSlots()
        {
            var times = new List<string>();

            for (int hour = 0; hour < 24; hour++) 
            {
                for (int minute = 0; minute < 60; minute += 15) // 15-minute intervals
                {
                    times.Add(new DateTime(1, 1, 1, hour, minute, 0).ToString("hh:mm tt")); // 12-hour format
                }
            }

            return times;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Event ev)
        {
            if (!ModelState.IsValid) {
                ev.TimeSlots = GenerateTimeSlots(); // Ensure the dropdown has values after validation fails
                return View(ev);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();
            ev.OrganizerId = user.UserName;
            ev.OrganizerName = user.FullName;
            _event.CreateEvent(ev);
            return RedirectToAction("AllEvents");
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
            return RedirectToAction("AllEvents");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _event.DeleteEvent(id);
            return RedirectToAction("AllEvents");
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
            return RedirectToAction("Login","Auth");
            
        }
        [Authorize]
        public async Task<IActionResult> MyEvents()
        {
            var userId = _userManager.GetUserId(User);
            var registeredEvents = await _eventRegistration.GetUserRegisteredEventsAsync(userId);

            return View(registeredEvents);
        }
        
        public async Task<IActionResult> AllEvents()
        {
           
            ViewBag.isAdmin = User.IsInRole("Admin");
            ViewBag.IsUser = User.IsInRole("User");
            ViewBag.IsOrganizer = User.IsInRole("Organizer");
            var user= await _userManager.GetUserAsync(User);
            if (user != null)
            {
                ViewBag.OrganizerName = user.FullName;
            }
                
            List<Event> EventList = _event.GetEvents().ToList();
            return View(EventList);
        }
    }
}
