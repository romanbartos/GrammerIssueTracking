using Grammer.IssueTracking.Core.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Grammer.IssueTracking.Core
{
    internal class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KnihaMap());
        }
    }
}
