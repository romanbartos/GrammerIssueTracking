using Grammer.IssueTracking.Core.Mappers;
using Grammer.IssueTracking.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Grammer.IssueTracking.Core
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KnihaMap());
        }
        
        public DbSet<Kniha> Books { get; set; }
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        // }
    }
}