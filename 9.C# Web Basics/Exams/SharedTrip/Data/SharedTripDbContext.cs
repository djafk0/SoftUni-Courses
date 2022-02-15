using Microsoft.EntityFrameworkCore;
using SharedTrip.Models;

namespace SharedTrip.Data
{
    public class SharedTripDbContext : DbContext
    {
        public SharedTripDbContext()
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>()
                .HasKey(u => new { u.UserId, u.TripId });
        }
    }
}
