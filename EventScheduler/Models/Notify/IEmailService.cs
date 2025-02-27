namespace EventScheduler.Models
{
    public interface IEmailService
    {
        public Task<bool> SendEmailAsync(string ToEmail, string subject, string body);
    }
}
