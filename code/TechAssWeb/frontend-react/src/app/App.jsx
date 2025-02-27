import { useMemo } from 'react';
import { createBrowserRouter, RouterProvider, Outlet } from "react-router";
import { NavigationComponent } from "./components/Navigation";
import { HomePage } from "./pages/Home";

const createAppRouter = () => createBrowserRouter([
    {
        path: "/",
        element: <Layout />,
        children: [
            {
                index: true,
                element: <HomePage />
            }
        ]
    }
]);

function Layout() {
    return (
        <div className="container-fluid">
            <NavigationComponent />
            <Outlet />
        </div>
    );
}

export function App() {
    const router = useMemo(() => createAppRouter(), []);
    return (
        <RouterProvider router={router} />
    );
}

