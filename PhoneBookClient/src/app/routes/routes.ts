import {createBrowserRouter} from "react-router";
import {
    CreatePhonePage,
    CreateUserPage,
    Home,
    UsersPage,
    PhonesPage,
    UpdatePhonePage,
    UpdateUserPage,
} from "@/pages";

export const router = createBrowserRouter([
    {
        path: "/",
        Component: Home,
    },
    {
        path: "users",
        children: [
            {
                index: true,
                Component: UsersPage
            },
            {
                path: "create",
                Component: CreateUserPage
            },
            {
                path: "update",
                Component: UpdateUserPage
            }
        ]
    },
    {
        path: "phones",
        children: [
            {
                index: true,
                Component: PhonesPage
            },
            {
                path: "create",
                Component: CreatePhonePage
            },
            {
                path: "update",
                Component: UpdatePhonePage
            }
        ]
    },
]);