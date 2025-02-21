using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventScheduler.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Event> Events { get; set; }
    }
}
