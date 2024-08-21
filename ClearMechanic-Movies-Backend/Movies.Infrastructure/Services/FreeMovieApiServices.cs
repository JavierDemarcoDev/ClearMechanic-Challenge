using Movies.Application.Contracts;
using Movies.Application.Models.Responses.Externals;
using Movies.Application.Constants;
using System.Text.Json;

namespace Movies.Infrastructure.Services;

public class FreeMovieApiServices : IFreeMovieApiServices
{
    protected string moviesUrl = UrlValues.FreeMovieApi.GetMoviesUrl();

    public async Task<List<FreeMovieApiResponse>> GetMovies()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, moviesUrl);
        var response = client.SendAsync(request).Result;

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var moviesResponse = JsonSerializer.Deserialize<List<FreeMovieApiResponse>>(jsonResponse);
            return moviesResponse;
        }

        return [];
    }
}
