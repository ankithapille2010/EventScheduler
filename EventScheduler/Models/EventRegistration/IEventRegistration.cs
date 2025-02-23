namespace EventScheduler.Models
{
    public interface IEventRegistration
    {
        Task RegisterForEventAsync(string userId, int eventId);
        Task<IEnumerable<Event>> GetUserRegisteredEventsAsync(string userId);
    }
}
