using Microsoft.EntityFrameworkCore;

namespace Mission08Group4_7.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<TaskClass> Tasks { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                new Categories { CategoryId = 1, Category = "Home" },
                new Categories { CategoryId = 2, Category = "School" },
                new Categories { CategoryId = 3, Category = "Work" },
                new Categories { CategoryId = 4, Category = "Church" }
            );
        }

    }
}
