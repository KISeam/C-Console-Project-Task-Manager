// AppDbContext.cs

using Microsoft.EntityFrameworkCore;

namespace TaskManagerCLI
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tasks.db");
        }
    }
}
