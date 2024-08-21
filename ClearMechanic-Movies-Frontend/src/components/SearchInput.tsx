import React, { Dispatch, SetStateAction } from 'react';
import { TextField, IconButton, CircularProgress, InputAdornment } from '@mui/material';
import SearchIcon from '@mui/icons-material/Search';

interface SearchProps {
    setValue: Dispatch<SetStateAction<string>>;
    onSearch: () => void;
    isLoading: boolean;
    value: string;
}

export const SearchInput: React.FC<SearchProps> = ({ onSearch, isLoading, value, setValue }) => {
    const handleKeyDown = (event: React.KeyboardEvent<HTMLDivElement>) => {
        if (event.key === 'Enter') {
            onSearch();
        }
    };

    return (
        <TextField
            value={value}
            onChange={(e) => setValue(e.target.value)}
            placeholder="Search..."
            variant="outlined"
            size="small"
            sx={{
                background: "white"
            }}
            fullWidth
            InputProps={{
                endAdornment: (
                    <InputAdornment position="end">
                        {isLoading ? (
                            <CircularProgress size={24} />
                        ) : (
                            <IconButton
                                onClick={onSearch}
                                color="primary"
                                size="small"
                            >
                                <SearchIcon />
                            </IconButton>
                        )}
                    </InputAdornment>
                )
            }}
            disabled={isLoading}
            onKeyDown={handleKeyDown}
        />
    );
};
