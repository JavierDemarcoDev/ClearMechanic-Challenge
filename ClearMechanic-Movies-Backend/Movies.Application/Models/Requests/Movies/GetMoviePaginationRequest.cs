using Movies.Application.Models.Requests.Handlers;

namespace Movies.Application.Models.Requests.Movies;

public abstract record GetMoviePaginationRequest : PaginationHandler
{
    public string Title { get; set; }
    public string Actor { get; set; }
    public string Genre { get; set; }
}
