using Movies.Domain.Common;
using Movies.Domain.Entities.Relational;

namespace Movies.Domain.Entities;

public class Actor : DimEntity
{
    public ICollection<MovieActor> MovieActors { get; set; } = [];
}
