using Pegasus.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pegasus.Data.Mapping {
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer> {
        public void Configure(EntityTypeBuilder<Trainer> builder) {
            builder.ToTable("Trainer");
            builder.HasKey(t => t.Name);
        }
    }
}
