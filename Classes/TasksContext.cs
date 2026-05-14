using Microsoft.EntityFrameworkCore;
using TaskManager_Khodzhiev.Classes.Database;

namespace TaskManager_Khodzhiev.Classes
{
    class TasksContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public TasksContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.Connection, Config.Version);
        }
    }
}
