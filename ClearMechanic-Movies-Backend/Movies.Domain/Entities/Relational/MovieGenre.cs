﻿namespace Movies.Domain.Entities.Relational;

public class MovieGenre
{
    public long MovieId { get; set; }
    public Movie Movie { get; set; } = null!;

    public long GenreId { get; set; }
    public Genre Genre { get; set; } = null!;
}
