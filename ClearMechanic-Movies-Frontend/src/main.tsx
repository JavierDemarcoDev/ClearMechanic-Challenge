import { createRoot } from 'react-dom/client'

import { CssBaseline, ThemeProvider } from '@mui/material'

import theme from './theme/theme.ts'
import { Movies } from './modules/index.ts'

import './theme/global.css'
import { Provider } from 'react-redux'
import { store } from './redux/store.ts'

createRoot(document.getElementById('root')!).render(
    <ThemeProvider theme={theme}>
        <CssBaseline />
        <Provider store={store}>
            <Movies />
        </Provider>
    </ThemeProvider>
)