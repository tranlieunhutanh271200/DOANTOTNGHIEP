import { useState } from "react";
import { Link } from "react-router-dom";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";

function RegisterPage() {
  const [email, setEmail] = useState("");
  const MySwal = withReactContent(Swal)
  const openModal = () => {
    MySwal.fire({
      title: "Instruction",
      html: <p1>Step 1: Register with us by using your school domain <br></br> Step 2: Our staffs will contact you for validation <br></br> Step 3: Start using our system</p1>,
      icon: "info",
      confirmButtonText: "Cool",
    });
  };
  return (
    <div className="forgot_page">
      <h1>Forgot Password</h1>
      <form className="form">
        <div>
          <input
            onChange={(e) => setEmail(e.target.value)}
            type="email"
            placeholder="Enter your email here..."
          />
        </div>
        <span>
          <ion-icon
            onClick={() => openModal()}
            size="large"
            name="help-circle-outline"
          ></ion-icon>
        </span>
      </form>
      <div className="submit">
        <button>
          Register <ion-icon size="large" name="send-outline"></ion-icon>
        </button>
      </div>
      <div className="forgot">
        <Link to={"/"}>Login</Link>
      </div>
    </div>
  );
}

export default RegisterPage;
