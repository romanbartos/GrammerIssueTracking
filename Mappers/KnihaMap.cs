using GrammerIssueTracking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammerIssueTracking.Mappers
{
    class KnihaMap : IEntityTypeConfiguration<Kniha>
    {
        public void Configure(EntityTypeBuilder<Kniha> builder)
        {
            builder.ToTable("kniha", "dbo");
            builder.HasKey(o => o.ID);
            builder.Property(o => o.ID).HasColumnName("ID");

            builder.Property(o => o.ID_Oddeleni).HasColumnName("ID_Oddeleni");
            builder.Property(o => o.ID_OddeleniVzniku).HasColumnName("ID_OddeleniVzniku");
        }
    }
}
