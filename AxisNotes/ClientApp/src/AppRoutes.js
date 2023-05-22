import { Home } from "./components/Home";
import NotesPage from "./components/NotesComponents/NotesPage";
import LoginRegisterPage from "./components/AuthComponents/LoginRegisterPage";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/anotes',
        element: <NotesPage />
    },
    {
        path: '/login',
        element: <LoginRegisterPage isRegister={ false }></LoginRegisterPage>
    },
    {
        path: '/register',
        element: <LoginRegisterPage isRegister={ true }></LoginRegisterPage>
    }
];

export default AppRoutes;
