import { createAsyncThunk } from "@reduxjs/toolkit";
import { MovieService } from "../../../services/movies/movieServices";
import { IGetPageParamas } from "../../../services/movies/endpoints";
import { IMovie } from "./moviesTypes";
import { IPagination } from "../../store";

export const getMoviesAsyncAction = createAsyncThunk<
    { data: IPagination<IMovie>; params?: IGetPageParamas },
    { params?: IGetPageParamas; }
>("moviesSlice/getMoviesAsyncAction", async ({ params }, { rejectWithValue }) => {
    try {
        const response = await MovieService.getMovies(params);

        if (response.status !== 200) {
            throw response
        }

        return {
            data: response.data.data,
            params
        };
    } catch (err: unknown) {
        return rejectWithValue(err instanceof Error ? err.message : "Unknown error");
    }
});
