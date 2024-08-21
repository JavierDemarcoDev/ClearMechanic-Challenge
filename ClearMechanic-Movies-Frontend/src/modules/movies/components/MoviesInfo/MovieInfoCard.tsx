import React from "react";
import { Card, Fade, Stack, Typography, CardMedia } from "@mui/material";
import { IMovie } from "../../../../redux/reducers/movies";

import styles from '../styles.module.css';

interface IMovieInfoCard {
  movie: IMovie;
}

export const MovieInfoCard: React.FC<IMovieInfoCard> = ({ movie: { title, poster, actors, genres, rating } }) => {
  return (
    <Fade timeout={350} in>
      <Card className={styles.cardContainer}>
        <CardTitle>{title}</CardTitle>
        <CardImage {...{ title, poster }} />
        <CardRating {...{ rating }} />
        <CardActors {...{ actors }} />
        <CardGenres {...{ genres }} />
      </Card>
    </Fade>
  );
};

const CardTitle: React.FC<{
  children: React.ReactNode;
}> = ({ children }) =>
    <Typography variant="h1" sx={{ fontSize: "1.8em", fontWeight: "bolder" }} color="primary">{children}</Typography>;

const CardImage: React.FC<{
  poster: string;
  title: string;
}> = ({
  poster,
  title
}) => (
    <CardMedia
      component="img"
      src={poster}
      alt={title}
      loading="lazy"
      className={styles.cardImage}
      sx={{
        height: 'auto',
        width: '100%',
        objectFit: 'cover',
      }}
    />
  );

const CardRating: React.FC<{
  rating: number;
}> = ({
  rating
}) => <Typography color="primary" fontWeight="bolder">Rating: {rating}</Typography>;

const CardActors: React.FC<{
  actors: string[];
}> = ({
  actors
}) =>
    <Stack>
      <Typography color="primary" fontWeight="bolder">Actors:</Typography>
      <Typography fontWeight="bolder">{actors.join(", ")}</Typography>
    </Stack>;

const CardGenres: React.FC<{
  genres: string[];
}> = ({
  genres
}) =>
    <Stack>
      <Typography color="primary" fontWeight="bolder">Genres:</Typography>
      <Typography fontWeight="bolder">{genres.join(", ")}</Typography>
    </Stack>;
