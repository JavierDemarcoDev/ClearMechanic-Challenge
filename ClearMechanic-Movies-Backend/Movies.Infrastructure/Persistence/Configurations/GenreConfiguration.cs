using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;
using Movies.Infrastructure.Persistence.Configurations.Common;

namespace Movies.Infrastructure.Persistence.Configurations;

public class GenreConfiguration(string keyName = "PK_Genre") : DimEntityConfiguration<Genre>(keyName)
{
    public override void Configure(EntityTypeBuilder<Genre> builder) => base.Configure(builder);
}
