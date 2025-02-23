namespace EventScheduler.Models
{
    public class EventRegistration1
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }

        // Navigation properties
        public Event Event { get; set; }
        public ApplicationUser User { get; set; }
    }
}
