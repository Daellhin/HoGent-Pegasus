using Pegasus.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pegasus.Data.Mapping {
    public class WeekTemplateConfiguration : IEntityTypeConfiguration<WeekTemplate> {
        public void Configure(EntityTypeBuilder<WeekTemplate> builder) {
            builder.ToTable("WeekTemplate");
            builder.HasKey(t => t.Id);

        }
    }
}
