using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Entities;

namespace SchoolSchedule.Repository
{
    internal class ApplicationContext : DbContext
    {
        private readonly string _connectionString;
       public DbSet<Schedule> Schedules { get; set; } = null!;       
       public ApplicationContext(string connectionString)
       {
            _connectionString = connectionString;
            Database.EnsureCreated();
       }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().ToTable("schelduletable");
            modelBuilder.Entity<Schedule>().HasNoKey();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
