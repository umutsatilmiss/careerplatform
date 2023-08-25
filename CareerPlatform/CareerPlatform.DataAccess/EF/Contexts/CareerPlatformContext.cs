using CareerPlatform.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerPlatform.DataAccess.EF.Contexts
{
    public class CareerPlatformContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("SERVER=DESKTOP-3K959DP\\SQLEXPRESS; Database = CareerPlatform; trusted_connection = true;");
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
