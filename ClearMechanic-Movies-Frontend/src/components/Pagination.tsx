import React from 'react';
import { Pagination as MuiPagination, Stack } from '@mui/material';

interface PaginationProps {
    count: number;
    page: number;
    onPageChange: (event: React.ChangeEvent<unknown>, value: number) => void;
    siblingCount?: number;
    boundaryCount?: number;
    size?: 'small' | 'medium' | 'large';
    color?: 'standard' | 'primary' | 'secondary';
    shape?: 'circular' | 'rounded';
    disabled?: boolean;
}

export const Pagination: React.FC<PaginationProps> = ({
    count,
    page,
    onPageChange,
    siblingCount = 1,
    boundaryCount = 1,
    size = 'medium',
    color = 'primary',
    shape = 'rounded',
    disabled
}) => {
    return (
        <Stack spacing={2} alignItems="center">
            <MuiPagination
                count={count}
                page={page}
                onChange={onPageChange}
                siblingCount={siblingCount}
                boundaryCount={boundaryCount}
                size={size}
                color={color}
                shape={shape}
                disabled={disabled}
            />
        </Stack>
    );
};