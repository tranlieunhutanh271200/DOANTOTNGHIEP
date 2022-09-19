import WrapperComponent from "../components/wrapper/wrapper.component";
import SignInPage from "../pages/auth/signin.page";
import ChatPage from "../pages/chat/chat.page";
import HomePage from "../pages/home/home.page";
import NotfoundPage from "../pages/notfound/notfound.page";

const routes = [
    {
        path: "/dashboard",
        exact: true,
        main: () => <HomePage/>,
        guard: true,
    },
    {
        main: () => <NotfoundPage></NotfoundPage>,
    },
];
export default routes;
