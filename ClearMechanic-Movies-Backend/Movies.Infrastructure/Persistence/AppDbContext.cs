using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Entities.Relational;
using Movies.Infrastructure.Persistence.Configurations;

namespace Movies.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> context) : DbContext(context)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.ApplyConfiguration(new ActorConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieActor> MoviesActors { get; set; }
    public DbSet<MovieGenre> MoviesGenres { get; set; }
    public DbSet<Migration> Migrations { get; set; }
}
