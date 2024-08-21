using AutoMapper;
using MediatR;
using Movies.Application.Contracts;
using Movies.Application.Models.Requests.Movies;
using Movies.Application.Models.Responses.DTOs;
using Movies.Application.Models.Responses.Handlers;

namespace Movies.Application.Features.V1.Movies.Queries;

public record GetMoviePaginationQuery : GetMoviePaginationRequest, IRequest<Result<Pagination<MovieDto>>>
{
}

public class GetMoviePaginationQueryHandler(
    IMovieServices _movieService,
    IMapper _mapper
    ) : IRequestHandler<GetMoviePaginationQuery, Result<Pagination<MovieDto>>>
{
    public async Task<Result<Pagination<MovieDto>>> Handle(GetMoviePaginationQuery query, CancellationToken cancellationToken)
    {
        var movies = await _movieService.GetPaginationAsync(query);
        return Result<Pagination<MovieDto>>.Success(_mapper.Map<Pagination<MovieDto>>(movies));
    }
}
