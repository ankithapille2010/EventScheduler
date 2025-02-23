
using Microsoft.EntityFrameworkCore;

namespace EventScheduler.Models
{
    public class EventRegistrationRegistry : IEventRegistration
    {
        public readonly ApplicationDbContext _context;
        public EventRegistrationRegistry(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<IEnumerable<Event>> GetUserRegisteredEventsAsync(string userId)
        {
            return await _context.EventRegistrations
             .Where(r => r.UserId == userId)
             .Select(r => r.Event)
             .ToListAsync();
        }

        public async Task RegisterForEventAsync(string userId, int eventId)
        {
            var registration = new EventRegistration1
            {
                UserId = userId,
                EventId = eventId
            };

            _context.EventRegistrations.Add(registration);
            await _context.SaveChangesAsync();
        }

    }
}
