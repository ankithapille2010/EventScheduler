
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventScheduler.Models
{
    public class Event : IEvent
    {
        private readonly ApplicationDbContext _context;
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Time { get; set; }
        public int? Duration { get; set; }

        public string? OrganizerId { get; set; }

        public string? OrganizerName {get; set;}

        // Navigation property for registrations
        public ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();
        [NotMapped]
        public List<string> TimeSlots { get; set; } = new List<string>();// Dropdown data

        public Event(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public Event() {
           
        }
        void IEvent.CreateEvent(Event _event)
        {
            _context.Add(_event);
            _context.SaveChanges();
        }

        void IEvent.DeleteEvent(int id)
        {
            var _event = _context.Events.FirstOrDefault(e => e.Id == id);
            if (_event != null)
            {
                _context.Remove(_event);
                _context.SaveChanges(true);
            }
        }

        void IEvent.EditEvent(Event _event)
        {
            _context.Events.Update(_event);
            _context.SaveChanges();
        }

        List<Event> IEvent.GetEvents()
        {
           return _context.Events.ToList();
        }

        Event? IEvent.GetEvent(int Id)
        {
            return (_context.Events.FirstOrDefault(ev => ev.Id == Id));
        }
    }
}
