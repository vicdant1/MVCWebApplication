using Microsoft.EntityFrameworkCore;
using MVCWebApplication.Models.Studies;

namespace MVCWebApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        { }

        public DbSet<Study> Studies { get; set; }
    }
}
