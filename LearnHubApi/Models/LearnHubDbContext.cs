using Microsoft.EntityFrameworkCore;

namespace LearnHubApi.Models
{
    public class LearnHubDbContext : DbContext
    {
        public LearnHubDbContext(DbContextOptions<LearnHubDbContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Enroll> enrolls { get; set; }
    }
}
