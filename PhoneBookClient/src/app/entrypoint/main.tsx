import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './../styles/index.css'
import { RouterProvider } from 'react-router'
import { router } from '../routes'
import { ThemeProvider } from "@/shared/config"

createRoot(document.getElementById('root')!).render(
  <StrictMode>
      <ThemeProvider defaultTheme="dark" storageKey="vite-ui-theme">
          <RouterProvider router={router} />
      </ThemeProvider>
  </StrictMode>,
)
