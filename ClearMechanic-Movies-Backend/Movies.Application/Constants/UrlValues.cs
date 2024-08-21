namespace Movies.Application.Constants;

public static class UrlValues
{
    public static class FreeMovieApi
    {
        public const string BaseUrl = "https://freetestapi.com/api/v1";
        public static string GetMoviesUrl() => $"{BaseUrl}/movies";
    }
}
