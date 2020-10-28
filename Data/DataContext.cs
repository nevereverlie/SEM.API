using Microsoft.EntityFrameworkCore;
using Revisory_Control.API.Models;

namespace RevisoryControl.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Users)
                .WithOne(d => d.Department)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Departments)
                .WithOne(c => c.Company)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Schedule>()
                .HasKey(k => new { k.UserId, k.WeekDayId });

            modelBuilder.Entity<User>()
                .HasMany(e => e.Schedules)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<WeekDay>()
                .HasMany(w => w.Schedules)
                .WithOne(w => w.WeekDay)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            
        } 
    }
}