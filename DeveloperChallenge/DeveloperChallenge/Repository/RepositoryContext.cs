using Microsoft.EntityFrameworkCore;
using DeveloperChallenge.Models;
using DeveloperChallenge.DAO;

namespace DeveloperChallenge.Repository
{
    /// <summary>
    /// Repository Context
    /// </summary>
    public class RepositoryContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Beer> Beer { get; set; }
        public DbSet<Ratings> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ratings>()
                .HasOne(r => r.Beer)          
                .WithMany(b => b.Ratings)    
                .HasForeignKey(r => r.BeerId)
                .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);
        }
    }
}