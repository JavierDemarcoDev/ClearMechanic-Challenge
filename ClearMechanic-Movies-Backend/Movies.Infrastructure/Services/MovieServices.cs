using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Contracts;
using Movies.Application.Features.V1.Movies.Queries;
using Movies.Application.Models.Helpers;
using Movies.Application.Models.Responses.Externals;
using Movies.Application.Models.Responses.Handlers;
using Movies.Domain.Common;
using Movies.Domain.Entities;
using Movies.Domain.Entities.Relational;
using Movies.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace Movies.Infrastructure.Services;

public class MovieServices(
    AppDbContext _context,
    IMapper _mapper
    ) : IMovieServices
{
    public async Task<Pagination<Movie>> GetPaginationAsync(GetMoviePaginationQuery query)
    {
        var movies = await _context.Movies
            .Where(GetOneMovieExpression(query))
            .Include(x => x.MovieGenres).ThenInclude(x => x.Genre)
            .Include(x => x.MovieActors).ThenInclude(x => x.Actor)
            .Skip(query.Offset * query.Limit)
            .Take(query.Limit)
            .ToListAsync();

        var totalCount = await _context.Movies
            .Where(GetOneMovieExpression(query))
            .CountAsync();

        return new Pagination<Movie>(movies, totalCount);
    }

    public async Task<string> MigrateFreeMoviesAsync(List<FreeMovieApiResponse> freeMovies)
    {
        var actorNames = freeMovies.SelectMany(movie => movie.Actors).Distinct().ToList();
        var genreNames = freeMovies.SelectMany(movie => movie.Genre).Distinct().ToList();

        var existingActors = await GetExistingEntities<Actor>(actorNames);
        var existingGenres = await GetExistingEntities<Genre>(genreNames);

        var newActors = await AddNewEntities(actorNames, existingActors);
        var newGenres = await AddNewEntities(genreNames, existingGenres);

        var movies = MapAndRelateMovies(
            freeMovies,
            [.. existingActors, .. newActors],
            [.. existingGenres, .. newGenres]);

        _context.Movies.AddRange(movies);
        _context.Migrations.Add(new Migration());
        var changes = await _context.SaveChangesAsync();

        return changes > 0 ? "Data migrated successfully" : "No changes were made to the database";
    }

    private async Task<List<T>> GetExistingEntities<T>(List<string> entityNames) where T : DimEntity
    {
        return await _context.Set<T>().Where(e => entityNames.Contains(e.Name)).ToListAsync();
    }

    private async Task<List<T>> AddNewEntities<T>(List<string> entityNames, List<T> existingEntities) where T : DimEntity, new()
    {
        var newEntityNames = entityNames.Except(existingEntities.Select(e => e.Name)).ToList();
        var newEntities = newEntityNames.Select(name => new T { Id = IdGenerator.UniqueId(), Name = name }).ToList();

        if (newEntities.Any())
        {
            _context.Set<T>().AddRange(newEntities);
            await _context.SaveChangesAsync();
        }

        return newEntities;
    }

    private List<Movie> MapAndRelateMovies(
        List<FreeMovieApiResponse> freeMovies,
        List<Actor> actors,
        List<Genre> genres)
    {
        var movieActors = new List<MovieActor>();
        var movieGenres = new List<MovieGenre>();

        var movies = freeMovies.Select(freeMovie =>
        {
            var movie = _mapper.Map<Movie>(freeMovie);
            movie.Id = IdGenerator.UniqueId();

            var relatedActors = freeMovie.Actors
                .Select(actorName => actors.First(a => a.Name == actorName))
                .ToList();

            movieActors.AddRange(relatedActors.Select(actor => new MovieActor
            {
                MovieId = movie.Id,
                ActorId = actor.Id
            }));

            var relatedGenres = freeMovie.Genre
                .Select(genreName => genres.First(g => g.Name == genreName))
                .ToList();

            movieGenres.AddRange(relatedGenres.Select(genre => new MovieGenre
            {
                MovieId = movie.Id,
                GenreId = genre.Id
            }));

            return movie;
        }).ToList();

        _context.MoviesActors.AddRange(movieActors);
        _context.MoviesGenres.AddRange(movieGenres);

        return movies;
    }

    private static Expression<Func<Movie, bool>> GetOneMovieExpression(GetMoviePaginationQuery query)
    {
        if (!string.IsNullOrEmpty(query.Title))
        {
            return movie => movie.Title.Contains(query.Title);
        }

        if (!string.IsNullOrEmpty(query.Genre))
        {
            return movie => movie.MovieGenres.Any(mg => mg.Genre.Name.Contains(query.Genre));
        }

        if (!string.IsNullOrEmpty(query.Actor))
        {
            return movie => movie.MovieActors.Any(ma => ma.Actor.Name.Contains(query.Actor));
        }

        return movie => true;
    }

    public async Task<bool> WasMigratedAlready()
    {
        return await _context.Migrations.AnyAsync();
    }
}
