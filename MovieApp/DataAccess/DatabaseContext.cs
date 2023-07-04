using Microsoft.EntityFrameworkCore;
using MovieApp.Infrastucture.Models;
using MovieApp.Models;
using System.Reflection;

namespace MovieApp.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MovieReview> Reviews { get; set; }
        public DbSet<MovieRecommended> Recommendations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<MovieRecommended>()
            .HasIndex(u => u.MovieId)
            .IsUnique();
        }
    }
}
