namespace Movies.Application.Models.Responses.DTOs;

public record MovieDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public decimal Rating { get; set; }
    public string Director { get; set; }
    public string Plot { get; set; }
    public string Poster { get; set; }
    public string Trailer { get; set; }
    public int Runtime { get; set; }
    public string Awards { get; set; }
    public string Country { get; set; }
    public string Language { get; set; }
    public string BoxOffice { get; set; }
    public string Production { get; set; }
    public string Website { get; set; }
    public IReadOnlyList<string> Genres { get; set; } = [];
    public IReadOnlyList<string> Actors { get; set; } = [];
}