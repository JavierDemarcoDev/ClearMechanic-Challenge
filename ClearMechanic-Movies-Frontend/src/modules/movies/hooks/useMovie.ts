import React from "react";

import { getMoviesAsyncAction } from "../../../redux/reducers/movies/moviesAction";
import { useAppDispatch, useAppSelector } from "../../../redux/store";
import { moviesState } from "../../../redux/reducers/movies";
import { IGetPageParamas } from "../../../services/movies/endpoints";

export type TSearchMovieTypeOptions = "title" | "actor" | "genre"

const searchOptions = [
    { label: 'Title', value: 'title' },
    { label: 'Actor', value: 'actor' },
    { label: 'Genre', value: 'genre' }
];

const limits = ["3", "6"]

export const useMovie = () => {
    const dispatch = useAppDispatch();

    const { data, isLoading, search } = useAppSelector(moviesState);

    const handleSearch = React.useCallback((params: IGetPageParamas) => {
        dispatch(getMoviesAsyncAction({
            params: {
                ...search,
                ...params
            }
        }));
    }, [dispatch, search]);

    const totalPages = React.useMemo(() => {
        const limit = Number(search.limit);
        return Math.ceil(data.totalCount / limit);
    }, [data.totalCount, search.limit]);

    React.useEffect(() => {
        dispatch(getMoviesAsyncAction({}));
    }, [dispatch]);

    return {
        handleSearch,
        isLoading,
        data,
        search,
        totalPages,
        searchOptions,
        limits
    }
}