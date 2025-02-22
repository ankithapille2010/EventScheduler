using System.Reflection;

namespace EventScheduler.Models
{
    public interface IEvent
    {
      
        public List<Event> GetEvents();
        public Event? GetEvent(int Id);
        public void CreateEvent(Event _event);
        public void EditEvent(Event _event);
        public void DeleteEvent(int id);


    }
}
