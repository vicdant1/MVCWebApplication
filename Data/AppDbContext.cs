using Microsoft.EntityFrameworkCore;
using MVCWebApplication.Models.Studies;
using MVCWebApplication.Models.Entertainment;

namespace MVCWebApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        { }

        public DbSet<Study> Studies { get; set; }

        public DbSet<MVCWebApplication.Models.Entertainment.Entertainment> Entertainment { get; set; }
    }
}
