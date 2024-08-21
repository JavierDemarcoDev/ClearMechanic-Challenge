import { createTheme } from '@mui/material/styles';

const theme = createTheme({
    palette: {
        primary: {
            main: '#42a5f5',
            contrastText: '#fff',
        },
        secondary: {
            main: '#f5f5f5',
            contrastText: '#333',
        },
        background: {
            default: '#fafafa',
            paper: '#fff',
        },
        text: {
            primary: '#333',
            secondary: '#333',
        },
        error: {
            main: "#f44336",
        },
    },
    typography: {
        fontFamily: 'Inter, system-ui, Avenir, Helvetica, Arial, sans-serif',
        fontSize: 16,
        h1: {
            fontSize: '1.25rem',
        },
        h2: {
            fontSize: '1rem',
        },
        h3: {
            fontSize: '0.875rem',
        },
        body1: {
            fontSize: '16px',
        },
    },
    shape: {
        borderRadius: 8,
    },
    components: {
        MuiButton: {
            styleOverrides: {
                root: {
                    borderRadius: 8,
                },
            },
        },
        MuiTextField: {
            styleOverrides: {
                root: {
                    borderRadius: 8,
                    backgroundColor: '#e0e0e0',
                    '& .MuiOutlinedInput-root': {
                        '& fieldset': {
                            borderColor: '#b0b0b0',
                        },
                        '&:hover fieldset': {
                            borderColor: '#b0b0b0',
                        },
                        '&.Mui-focused fieldset': {
                            borderColor: '#333',
                        },
                    },
                },
            },
        },
        MuiCard: {
            styleOverrides: {
                root: {
                    borderRadius: 8,
                    border: `1px solid #dcdcdc`,
                },
            },
        },
        MuiDialog: {
            styleOverrides: {
                paper: {
                    borderRadius: 8,
                },
            },
        },
        MuiAppBar: {
            styleOverrides: {
                root: {
                    borderBottom: `1px solid #dcdcdc`,
                },
            },
        },
    },
});

export default theme;
