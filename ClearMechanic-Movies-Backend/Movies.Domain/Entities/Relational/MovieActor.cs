namespace Movies.Domain.Entities.Relational;

public class MovieActor
{
    public long MovieId { get; set; }
    public Movie Movie { get; set; } = null!;

    public long ActorId { get; set; }
    public Actor Actor { get; set; } = null!;
}
