using Microsoft.EntityFrameworkCore;
using ShiftTracker.API.Models;

namespace ShiftTracker.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Shift> Shifts { get; set; }
    }
}
