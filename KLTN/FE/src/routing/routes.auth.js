import ForgotPage from "../pages/auth/forgot.page";
import RegisterPage from "../pages/auth/register.page";
import SignInPage from "../pages/auth/signin.page";
import NotfoundPage from "../pages/notfound/notfound.page";

const authRoutes = [
    {
        path: '/auth',
        exact: true,
        main: () => <SignInPage></SignInPage>
    },
    {
        path: '/register',
        exact: true,
        main: () => <RegisterPage></RegisterPage>
    },
    {
        path: '/forgot-password',
        exact: true,
        main: () => <ForgotPage></ForgotPage>
    },
    {
        main: () => <NotfoundPage></NotfoundPage>
    }
]
export default authRoutes;