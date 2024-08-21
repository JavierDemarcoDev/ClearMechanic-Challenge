namespace Movies.Application.Models.Requests.Handlers;

public abstract record PaginationHandler(int Offset = 0, int Limit = 5)
{
}
