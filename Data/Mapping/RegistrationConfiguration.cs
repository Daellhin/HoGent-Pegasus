using Pegasus.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pegasus.Data.Mapping {
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration> {
        public void Configure(EntityTypeBuilder<Registration> builder) {
            builder.ToTable("Inschrijving");
            builder.HasKey(t => t.Id);

        }
    }
}
