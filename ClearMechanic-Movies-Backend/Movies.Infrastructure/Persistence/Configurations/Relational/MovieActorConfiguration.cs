using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities.Relational;

namespace Movies.Infrastructure.Persistence.Configurations.Relational;

public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
{
    public void Configure(EntityTypeBuilder<MovieActor> builder)
    {
        builder.ToTable(typeof(MovieActor).Name);
        builder.HasKey(mg => new { mg.MovieId, mg.ActorId })
            .HasName("PK_MovieActor");

        builder.HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieActors)
            .HasForeignKey(mg => mg.MovieId)
            .HasConstraintName("FK_MovieActor_Movie")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(mg => mg.Actor)
            .WithMany(g => g.MovieActors)
            .HasForeignKey(mg => mg.ActorId)
            .HasConstraintName("FK_MovieActor_Actor")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
