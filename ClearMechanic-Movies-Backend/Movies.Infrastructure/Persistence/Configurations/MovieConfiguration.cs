using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;

namespace Movies.Infrastructure.Persistence.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable(nameof(Movie));
        builder.HasKey(x => x.Id).HasName("PK_Movie");
        builder.Property(x => x.Id).HasColumnType("bigint").ValueGeneratedNever().IsRequired();
        builder.Property(x => x.Title).HasColumnType("nvarchar(256)").IsRequired();
        builder.Property(x => x.Year).HasColumnType("int").IsRequired();
        builder.Property(x => x.Rating).HasColumnType("decimal(3,2)").IsRequired();
        builder.Property(x => x.Director).HasColumnType("nvarchar(256)").IsRequired();
        builder.Property(x => x.Plot).HasColumnType("nvarchar(max)").IsRequired();
        builder.Property(x => x.Poster).HasColumnType("nvarchar(512)").IsRequired();
        builder.Property(x => x.Trailer).HasColumnType("nvarchar(512)").IsRequired();
        builder.Property(x => x.Runtime).HasColumnType("int").IsRequired();
        builder.Property(x => x.Awards).HasColumnType("nvarchar(512)").IsRequired();
        builder.Property(x => x.Country).HasColumnType("nvarchar(128)").IsRequired();
        builder.Property(x => x.Language).HasColumnType("nvarchar(128)").IsRequired();
        builder.Property(x => x.BoxOffice).HasColumnType("nvarchar(64)").IsRequired();
        builder.Property(x => x.Production).HasColumnType("nvarchar(256)").IsRequired();
        builder.Property(x => x.Website).HasColumnType("nvarchar(512)").IsRequired();
    }
}
