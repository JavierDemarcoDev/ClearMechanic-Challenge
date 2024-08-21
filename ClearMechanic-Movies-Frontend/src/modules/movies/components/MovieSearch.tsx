import React from "react";
import { Button, Grid, Paper, SelectChangeEvent } from "@mui/material";

import { SearchInput } from "../../../components";
import { useMovie } from "../hooks/useMovie";
import { Pagination } from "../../../components/Pagination";
import { Select } from "../../../components/Select";
import { initialMoviesState } from "../../../redux/reducers/movies";

export const MovieSearch = () => {
    const { handleSearch, isLoading, search, totalPages, searchOptions, limits, data } = useMovie();
    const [selectType, setSelectType] = React.useState<string>(searchOptions[0].value);
    const [input, setInput] = React.useState<string>('');

    const handlePageChange = (_: React.ChangeEvent<unknown>, value: number) => {
        if (value >= 1 && value <= totalPages) {
            handleSearch({
                ...search,
                offset: (value - 1).toString()
            });
        }
    };

    const handleInputChange = () => {
        handleSearch({
            ...search,
            offset: initialMoviesState.search.offset,
            [selectType]: input
        });
    };

    const handleSelectLimit = (e: SelectChangeEvent<string>) => {
        handleSearch({
            ...search,
            offset: "1",
            limit: e.target.value
        });
    };

    const handleResetQuery = () => {
        setInput("");
        setSelectType(searchOptions[0].value);
        handleSearch(initialMoviesState.search);
    };

    const handleSelectChange = (e: SelectChangeEvent<string>) => {
        setSelectType(e.target.value);
    };

    const hasItems = data.items.length > 0;

    return (
        <Grid container component={Paper} sx={{ padding: "16px 28px" }} display="flex" alignItems="center">
            <Grid item xs={12} md={2}>
                <Button onClick={handleResetQuery} variant="contained">Reset Query Params</Button>
            </Grid>
            <Grid item xs={12} md={4} display="flex" justifyContent="flex-start" alignItems="center" gap={2}>
                <Select
                    value={selectType}
                    onChange={handleSelectChange}
                    options={searchOptions}
                    label="Search type"
                    fullWidth
                />
                <SearchInput {...{ isLoading }} onSearch={handleInputChange} value={input} setValue={setInput} />
            </Grid>
            {totalPages > 0 && (
                <Grid item xs={12} md={6} display="flex" justifyContent="flex-end" alignItems="center" gap={2}>
                    <Pagination
                        count={totalPages}
                        page={Number(search.offset) + 1}
                        onPageChange={handlePageChange}
                        siblingCount={2}
                        boundaryCount={1}
                        size="large"
                        color="primary"
                        shape="rounded"
                        disabled={isLoading}
                    />
                    <Select
                        value={search.limit}
                        onChange={handleSelectLimit}
                        options={limits.map((limit) => ({ value: limit, label: limit }))}
                        disabled={totalPages === 0 || !hasItems}
                    />
                </Grid>
            )}
        </Grid>
    );
};
