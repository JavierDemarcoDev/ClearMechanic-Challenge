using System.Text.Json.Serialization;

namespace Movies.Application.Models.Responses.Externals;

public class FreeMovieApiResponse
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }

    [JsonPropertyName("year")] public int Year { get; set; }

    [JsonPropertyName("rating")] public double Rating { get; set; }

    [JsonPropertyName("director")] public string Director { get; set; }

    [JsonPropertyName("plot")] public string Plot { get; set; }

    [JsonPropertyName("poster")] public string Poster { get; set; }

    [JsonPropertyName("trailer")] public string Trailer { get; set; }

    [JsonPropertyName("runtime")] public int Runtime { get; set; }

    [JsonPropertyName("awards")] public string Awards { get; set; }

    [JsonPropertyName("country")] public string Country { get; set; }

    [JsonPropertyName("language")] public string Language { get; set; }

    [JsonPropertyName("boxOffice")] public string BoxOffice { get; set; }

    [JsonPropertyName("production")] public string Production { get; set; }

    [JsonPropertyName("website")] public string Website { get; set; }

    [JsonPropertyName("genre")] public List<string> Genre { get; set; }

    [JsonPropertyName("actors")] public List<string> Actors { get; set; }
}