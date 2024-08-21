using MediatR;
using Movies.Application.Contracts;
using Movies.Application.Models.Responses.Externals;
using Movies.Application.Models.Responses.Handlers;

namespace Movies.Application.Features.V1.Movies.Command;

public class MigrateMoviesCommand : IRequest<Result<string>>
{
}

public class MigrateMoviesCommandHandler(
    IFreeMovieApiServices _freeMovieService,
    IMovieServices _movieService
    ) : IRequestHandler<MigrateMoviesCommand, Result<string>>
{
    private readonly string alreadyMigrated = "Migration has already been executed";
    public async Task<Result<string>> Handle(MigrateMoviesCommand request, CancellationToken cancellationToken)
    {
        if (await _movieService.WasMigratedAlready())
        {
            return Result<string>.Failure([alreadyMigrated]);
        }

        List<FreeMovieApiResponse> freeMovies = await _freeMovieService.GetMovies();
        var result = await _movieService.MigrateFreeMoviesAsync(freeMovies);

        return Result<string>.Success(result);
    }
}