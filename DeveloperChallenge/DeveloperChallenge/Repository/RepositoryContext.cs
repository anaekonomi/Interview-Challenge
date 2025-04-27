using Microsoft.EntityFrameworkCore;
using DeveloperChallenge.Models;

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
    }
}