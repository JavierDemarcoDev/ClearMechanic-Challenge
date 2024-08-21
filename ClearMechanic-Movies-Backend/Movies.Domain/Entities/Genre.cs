using Movies.Domain.Common;
using Movies.Domain.Entities.Relational;

namespace Movies.Domain.Entities;

public class Genre : DimEntity
{
    public ICollection<MovieGenre> MovieGenres { get; set; } = [];
}
