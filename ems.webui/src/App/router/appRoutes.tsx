import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../../App";
import { EventDashboardPage } from "../../features/events/pages/EventDashboardPage";
import { EventForm } from "../../features/events/pages/EventForm";

const appRoutes: RouteObject[] = [
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "events",
                element: <EventDashboardPage />,
                children: [
                    {
                        path: "create",
                        element: <EventForm />
                    }
                ]

            }
        ]
    },
]



export const router = createBrowserRouter(appRoutes);