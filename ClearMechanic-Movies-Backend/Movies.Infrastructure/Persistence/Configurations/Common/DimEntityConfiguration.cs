using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Common;

namespace Movies.Infrastructure.Persistence.Configurations.Common;

public class DimEntityConfiguration<T>(
    string keyName
    ) : IEntityTypeConfiguration<T>
    where T : DimEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(typeof(T).Name);
        builder.HasKey(x => x.Id).HasName(keyName);
        builder.Property(x => x.Id).HasColumnType("bigint").ValueGeneratedNever().IsRequired();
        builder.Property(x => x.Name).HasColumnType("nvarchar(512)").IsRequired();
    }
}
