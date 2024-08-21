import { configureStore } from '@reduxjs/toolkit'
import { moviesReducer } from './reducers/movies'
import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';

export const store = configureStore({
    reducer: {
        movies: moviesReducer,
    },
})

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;

export interface IState<TData> {
    data: TData;
    isLoading: boolean
}

export interface IPagination<TData> {
    items: TData[];
    totalCount: number;
}