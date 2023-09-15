using Microsoft.EntityFrameworkCore;
using vosplzen.sem1h2.Data.Model;

namespace vosplzen.sem1h2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Questionnaire> Questionnaires { get; set; }

    }
}
