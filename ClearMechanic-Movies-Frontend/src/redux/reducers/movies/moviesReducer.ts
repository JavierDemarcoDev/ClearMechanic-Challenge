import { createSlice } from "@reduxjs/toolkit";
import { IMovie } from "./moviesTypes";
import { IPagination, IState, RootState } from "../../store";
import { getMoviesAsyncAction } from "./moviesAction";
import { IGetPageParamas } from "../../../services/movies/endpoints";

interface IMovieSliceState extends IState<IPagination<IMovie>> {
    search: IGetPageParamas
}

export const initialMoviesState: IMovieSliceState = {
    data: {
        items: [],
        totalCount: 0
    },
    search: {
        offset: "0",
        limit: "3",
        title: "",
        actor: "",
        genre: ""
    },
    isLoading: false
}

export const moviesSlice = createSlice({
    name: 'moviesSlice',
    initialState: initialMoviesState,
    reducers: {},
    extraReducers(builder) {
        builder.addCase(getMoviesAsyncAction.pending, (state) => {
            state.isLoading = true;
        })
        builder.addCase(getMoviesAsyncAction.rejected, (state, { payload }) => {
            state.isLoading = false;
            console.error('Failed to fetch movies:', payload);
        })
        builder.addCase(getMoviesAsyncAction.fulfilled, (state, { payload }) => {
            state.isLoading = false;
            state.data.items = payload.data.items; // Reemplaza el array
            state.data.totalCount = payload.data.totalCount;
            state.search = { ...state.search, ...payload.params };
        });
    }
})

export const moviesState = (state: RootState) => state.movies
export const moviesReducer = moviesSlice.reducer