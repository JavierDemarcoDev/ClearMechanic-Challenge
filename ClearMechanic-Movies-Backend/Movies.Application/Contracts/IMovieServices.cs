using Movies.Application.Features.V1.Movies.Queries;
using Movies.Application.Models.Responses.Externals;
using Movies.Application.Models.Responses.Handlers;
using Movies.Domain.Entities;

namespace Movies.Application.Contracts;

public interface IMovieServices
{
    public Task<Pagination<Movie>> GetPaginationAsync(GetMoviePaginationQuery query);
    public Task<string> MigrateFreeMoviesAsync(List<FreeMovieApiResponse> movies);
    public Task<bool> WasMigratedAlready();
}
