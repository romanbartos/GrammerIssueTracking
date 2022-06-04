using Grammer.IssueTracking.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grammer.IssueTracking.Core.Mappers
{
    class KnihaMap : IEntityTypeConfiguration<Kniha>
    {
        public void Configure(EntityTypeBuilder<Kniha> builder)
        {
            builder.ToTable("kniha", "dbo");
            builder.HasKey(o => o.KnihaId);
            builder.Property(o => o.KnihaId).HasColumnName("ID");

            builder.Property(o => o.IdOddeleni).HasColumnName("ID_Oddeleni");
        }
    }
}
