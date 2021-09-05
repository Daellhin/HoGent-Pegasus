using Pegasus.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pegasus.Data.Mapping {
    public class TrainingConfiguration : IEntityTypeConfiguration<Training> {
        public void Configure(EntityTypeBuilder<Training> builder) {
            builder.ToTable("Training");
            builder.HasKey(t => t.Id);

        }
    }
}
