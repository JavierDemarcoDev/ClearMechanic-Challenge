using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;
using Movies.Infrastructure.Persistence.Configurations.Common;

namespace Movies.Infrastructure.Persistence.Configurations;

public class ActorConfiguration(string keyName = "PK_Actor") : DimEntityConfiguration<Actor>(keyName)
{
    public override void Configure(EntityTypeBuilder<Actor> builder) => base.Configure(builder);
}
