import { Grid } from "@mui/material";
import { MovieInfoCard } from "./MovieInfoCard";
import { useAppSelector } from "../../../../redux/store";
import { moviesState } from "../../../../redux/reducers/movies";

export const MoviesInfo = () => {
    const { data } = useAppSelector(moviesState);

    return (
        <Grid container spacing={2} padding={4}>
            {data.items.map((movie, index) => (
                <Grid item xs={12} md={4} key={index}>
                    <MovieInfoCard {...{ movie }} />
                </Grid>
            ))}
        </Grid>
    )
}