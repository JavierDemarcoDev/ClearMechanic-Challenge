using AutoMapper;
using Movies.Application.Models.Responses.DTOs;
using Movies.Application.Models.Responses.Externals;
using Movies.Application.Models.Responses.Handlers;
using Movies.Domain.Entities;

namespace Movies.Application.MappingProfile;

public class MoviesMapping : Profile
{
    public MoviesMapping()
    {
        CreateMap<Movie, MovieDto>()
            .ForMember(
                dest => dest.Genres,
                opt => opt.MapFrom(src => src.MovieGenres.Select(mg => mg.Genre.Name).ToList()))
            .ForMember(
                dest => dest.Actors,
                opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor.Name).ToList()));

        CreateMap<Pagination<Movie>, Pagination<MovieDto>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

        CreateMap<FreeMovieApiResponse, Movie>()
            .ForMember(dest => dest.MovieGenres, opt => opt.Ignore())
            .ForMember(dest => dest.MovieActors, opt => opt.Ignore());
    }
}
