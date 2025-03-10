using DeveloperPathways.Domain;
using DeveloperPathways.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Data
{
    public class TitanicContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }

        public TitanicContext(DbContextOptions<TitanicContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>()
                .HasKey(p => p.PassengerId);
        }
    }
}
