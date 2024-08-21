using Microsoft.AspNetCore.Mvc;
using Movies.API.Common;
using Movies.Application.Features.V1.Movies.Command;
using Movies.Application.Features.V1.Movies.Queries;
using Movies.Application.Models.Responses.DTOs;
using Movies.Application.Models.Responses.Handlers;

namespace Movies.API.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class MoviesController : ApiControllerBase
{
    /// <summary>
    /// Retrieves a paginated list of movies.
    /// </summary>
    /// <remarks>
    /// This method combines all query parameters into a single query management handler.
    /// It is designed to be flexible, allowing for reimplementation with different pagination methods.
    /// </remarks>
    /// <param name="query">Query parameters for pagination.</param>
    /// <returns>A paginated list of movies wrapped in a <see cref="Result{T}"/>.</returns>
    [HttpGet]
    public async Task<Result<Pagination<MovieDto>>> GetMoviesPagination([FromQuery] GetMoviePaginationQuery query) => await Mediator.Send(query);

    /// <summary>
    /// Initiates the movie migration process.
    /// </summary>
    /// <remarks>
    /// This method is designed to kick-start the project by consuming data from an external API.
    /// The external API URL is: https://freetestapi.com/api/v1.
    /// </remarks>
    /// <param name="request">The command containing the migration request data.</param>
    /// <returns>A result containing a string message indicating the migration status.</returns>
    [HttpPost("Migration")]
    public async Task<Result<string>> MigrateMovies(MigrateMoviesCommand request) => await Mediator.Send(request);
}
