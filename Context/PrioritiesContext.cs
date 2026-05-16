using Microsoft.EntityFrameworkCore;
using TaskManager_Khodzhiev.Classes.Database;
using TaskManager_Khodzhiev.Models;

namespace TaskManager_Khodzhiev.Context
{
    public class PrioritiesContext : DbContext
    {
        public DbSet<Priorities> Priorities { get; set; }
        public PrioritiesContext()
        {
            Database.EnsureCreated();
            Priorities.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.Connection, Config.Version);
        }
    }
}
