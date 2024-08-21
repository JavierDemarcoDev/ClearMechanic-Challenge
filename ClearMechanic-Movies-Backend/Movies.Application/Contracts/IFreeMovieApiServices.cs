using Movies.Application.Models.Responses.Externals;

namespace Movies.Application.Contracts;

public interface IFreeMovieApiServices
{
    public Task<List<FreeMovieApiResponse>> GetMovies();
}
