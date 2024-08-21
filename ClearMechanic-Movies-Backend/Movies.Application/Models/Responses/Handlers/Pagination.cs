namespace Movies.Application.Models.Responses.Handlers;

public record Pagination<T>(IReadOnlyList<T> Items, int TotalCount)
    where T : class, new()
{
}
