import { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { useLocation } from "react-router-dom";
import { useRouteMatch } from "react-router-dom";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";
import axiosClient from "../../global/axios/axiosClient";
import { signIn } from "../../redux/actions/Auth/auth.action";
import { ToastContainer } from "react-toastify";
import jwtDecode from "jwt-decode";
import toast  from 'react-hot-toast';
import "./auth.css";
function SignInPage() {
  const [account, setAccount] = useState({
    username: "",
    password: "",
  });
  const history = useHistory();
  const dispatch = useDispatch();
  const { url, path } = useRouteMatch();
  // useEffect(() => {
  //   document.addEventListener("keypress", (ev) => {
  //     if(ev.key === 'Enter'){
  //       signInClick();
  //     }
  //   })
  //   return () =>
  //     document.removeEventListener('keypress');
    
  // }, [])
  const signInClick = async () => {
    //calling api here
    // await signIn("1231");
    //remember to encrypt data
    console.log(account);
    const data = {
      domain: account.username.split("\\")[0],
      username: account.username.split("\\")[1],
      password: account.password,
    };
    console.log(data);
    if (data.domain === "admin") {
      history.push("/dashboard");
    } else {
      var result = await axiosClient.post("/api/login", data).catch((error)  => {
      });
      //check response
      if (result.data) {
        dispatch(signIn(result.data));
      }
      if (result.statusCode === 200) {
        const data = JSON.parse(result.data);
        toast.success(`Chào mừng bạn đến với hệ thống LMS của ${data.account.domain.schoolName}`)
        history.push("/dashboard/learn");
      }
    }
  };
  return (
    <div className="auth">
      <div className="authBox">
        <form className="form">
          <h1 className="login_title">Login</h1>
          <input
            required
            className="form-field"
            type="text"
            name="userName"
            autoComplete="false"
            placeholder="[domain]\[username]"
            onChange={(e) =>
              {
                setAccount({ ...account, username: e.target.value })
              }
            }
          />
          <input
            required
            className="form-field"
            type="password"
            name="password"
            autoComplete="false"
            placeholder="Password..."
            onChange={(e) =>
              setAccount({ ...account, password: e.target.value })
            }
          />
        </form>
        <div className="login">
          <button className="glass-button" onClick={signInClick}>
            Login <ion-icon size="large" name="log-in-outline"></ion-icon>
          </button>
        </div>
        <div className="forgot">
          <Link to={`${path}/fill-up`}>Register</Link> your school with us
        </div>
        <div className="forgot">
          Don't remember your password? Reset it{" "}
          <Link to={`${path}/forgot-pwd`}>here</Link>
        </div>
      </div>
    </div>
  );
}

export default SignInPage;
