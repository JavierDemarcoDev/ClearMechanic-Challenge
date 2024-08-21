using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;

namespace Movies.Infrastructure.Persistence.Configurations
{
    public class MigrationConfiguration : IEntityTypeConfiguration<Migration>
    {
        public void Configure(EntityTypeBuilder<Migration> builder)
        {
            builder.ToTable(nameof(Migration));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
