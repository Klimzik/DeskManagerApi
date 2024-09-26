using DeskManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DeskManagerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<DeskOccupancy> DeskOccupancies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeskOccupancy>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
