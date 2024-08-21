
import { Fade, Grid, Typography } from "@mui/material";

import { MovieSearch } from "./components/MovieSearch";
import { MoviesInfo } from "./components/MoviesInfo";
import { useMovie } from "./hooks/useMovie";

export const Movies = () => {
    const { data } = useMovie();
    return (
        <Grid container style={{ flexGrow: 1 }}>
            <Grid item xs={12} style={{ padding: '16px', flexShrink: 0 }}>
                <MovieSearch />
            </Grid>
            <Grid item xs={12} style={{ padding: '16px', flexShrink: 0 }} display="flex" justifyContent="center" alignItems="center">
                <Fade timeout={350} in>
                    {data.items.length > 0
                        ? <MoviesInfo />
                        : <Typography variant="h2" sx={{ fontSize: "1.8em", fontWeight: "bolder" }} color="primary">Movies not found</Typography>
                    }
                </Fade>
            </Grid>
        </Grid>
    );
};