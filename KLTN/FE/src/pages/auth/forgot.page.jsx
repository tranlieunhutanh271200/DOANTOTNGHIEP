import { useState } from "react";
import { Link } from "react-router-dom";

function ForgotPage() {
    const [email,setEmail] = useState('');
    const submit = () => {
        //submit reset email request here

        //redirect to inform page
    }
    return ( <div className="forgot_page">
        <h1>Forgot Password</h1>
        <form className="form">
            <div>
                <input onChange={(e) => setEmail(e.target.value)} type="email" placeholder="Enter your email here..."/>
            </div>
        </form>
        <div className="submit">
            <button>Reset <ion-icon size='large' name="send-outline"></ion-icon></button>
        </div>
        <div>
            <Link to={'/'}>Login</Link>
        </div>
    </div> );
}

export default ForgotPage;