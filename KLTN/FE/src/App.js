import "./css/styles.css";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import {
  BrowserRouter,
  Switch,
  Router,
  Route,
  useHistory,
  HashRouter,
} from "react-router-dom";
import { createBrowserHistory } from "history";
import routes from "./routing/routes.dashboard";
import WrapperComponent from "./components/wrapper/wrapper.component";
import NotfoundPage from "./pages/notfound/notfound.page";
import authRoutes from "./routing/routes.auth";
import AuthWrapper from "./pages/auth/auth.wrapper";
import MiddlewarePage from "./pages/auth/middleware.page";
import toast, { Toaster } from "react-hot-toast";
import { persist } from "./redux/actions/Auth/auth.action";
const App = () => {
  const history = createBrowserHistory();
  const dispatch = useDispatch();
  const renderRoutes = routes.map((route, idx) => {
    return (
      <Route
        key={idx}
        path={route.path}
        component={route.main}
        exact={route.exact}
      ></Route>
    );
  });
  const renderAuthRoutes = authRoutes.map((route, idx) => (
    <Route
      key={idx * 2}
      path={route.path}
      exact={route.exact}
      component={route.main}
    ></Route>
  ));
  // useEffect(() => {
  //   // if (isExpired) {
  //   //   localStorage.removeItem('account');
  //   //   localStorage.removeItem('token');
  //   //   history.push("/auth");
  //   // }
  //   console.log(isExpired);
  // }, [isExpired]);
  useEffect(() => {
    const persistData = async () => {
      console.log(localStorage.getItem("persist:root"));
      if (localStorage.getItem("persist:root") && localStorage.getItem("account")) {
        dispatch(await persist());
        if (window.location.pathname === "/auth") {
          history.push("/dashboard/learn");
        } else {
          history.push(window.location.pathname);
        }
      }else{
        history.push("/auth");
      }
    };
    persistData();
  }, []);

  return (
    <BrowserRouter>
      <Router history={history}>
        <Switch>
          <Route
            path={"/"}
            exact={true}
            component={() => <MiddlewarePage></MiddlewarePage>}
          ></Route>
          <Route path={"/auth"} exact={false}>
            <AuthWrapper></AuthWrapper>
          </Route>
          <Route path="/dashboard" exact={false}>
            <WrapperComponent></WrapperComponent>
          </Route>
        </Switch>
        <Toaster></Toaster>
      </Router>
    </BrowserRouter>
  );
};

export default App;
