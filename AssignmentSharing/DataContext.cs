using AssignmentSharing.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentSharing
{
    public class DataContext : DbContext
    {
        private IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("Sqlite"));
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
