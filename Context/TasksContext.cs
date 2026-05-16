using Microsoft.EntityFrameworkCore;
using TaskManager_Khodzhiev.Classes.Database;
using TaskManager_Khodzhiev.Models;

namespace TaskManager_Khodzhiev.Context
{
    class TasksContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
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
