import {
    MenuItem,
    SelectChangeEvent,
    FormControlProps,
    InputLabelProps,
    Select as MuiSelect,
} from "@mui/material";

interface ISelectProps {
    value: string;
    onChange: (event: SelectChangeEvent<string>) => void;
    options: { label: string; value: string }[];
    label?: string;
    formControlProps?: FormControlProps;
    inputLabelProps?: InputLabelProps;
    fullWidth?: boolean;
    disabled?: boolean;

}

export const Select = ({
    value,
    onChange,
    options,
    label,
    disabled,
    fullWidth
}: ISelectProps) => (
    <MuiSelect
        disabled={disabled}
        value={value}
        onChange={onChange}
        label={label}
        variant="standard"
        fullWidth={fullWidth}
    >
        {options.map((option, index) => (
            <MenuItem key={index} value={option.value}>
                {option.label}
            </MenuItem>
        ))}
    </MuiSelect>
);
