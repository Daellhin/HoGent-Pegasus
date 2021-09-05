using Pegasus.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pegasus.Data.Mapping {
    public class WeekConfiguration : IEntityTypeConfiguration<Week> {
        public void Configure(EntityTypeBuilder<Week> builder) {
            builder.ToTable("Week");
            builder.HasKey(t => t.Start);

        }
    }
}
