using Pegasus.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pegasus.Data.Mapping {
    public class TrainingTemplateConfiguration : IEntityTypeConfiguration<TrainingTemplate> {
        public void Configure(EntityTypeBuilder<TrainingTemplate> builder) {
            builder.ToTable("TrainingTemplate");
            builder.HasKey(t => t.Id);

        }
    }
}
