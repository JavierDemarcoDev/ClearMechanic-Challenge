using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities.Relational;

namespace Movies.Infrastructure.Persistence.Configurations.Relational;

public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
{
    public void Configure(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.ToTable(typeof(MovieGenre).Name);
        builder.HasKey(mg => new { mg.MovieId, mg.GenreId })
            .HasName("PK_MovieGenre");

        builder.HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(mg => mg.MovieId)
            .HasConstraintName("FK_MovieGenre_Movie")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(mg => mg.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(mg => mg.GenreId)
            .HasConstraintName("FK_MovieGenre_Genre")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
