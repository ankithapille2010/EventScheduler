
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace EventScheduler.Models
{
    public class Event : IEvent
    {
        private readonly ApplicationDbContext _context;
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Title { get; set; }

        // Navigation property for registrations
        public ICollection<EventRegistration> EventRegistrations { get; set; }

        public Event(ApplicationDbContext context)
        {
            _context = context;
        }
        public Event() { }
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
