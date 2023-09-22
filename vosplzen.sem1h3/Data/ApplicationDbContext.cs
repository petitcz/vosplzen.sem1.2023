using Microsoft.EntityFrameworkCore;
using vosplzen.sem1h3.Data.Model;

namespace vosplzen.sem1h3cons.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }

    }
}
