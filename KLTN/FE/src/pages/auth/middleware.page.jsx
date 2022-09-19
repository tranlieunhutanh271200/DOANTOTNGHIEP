import { Redirect } from "react-router-dom";

function MiddlewarePage() {
    return ( <Redirect to={'/auth'}></Redirect>);
}

export default MiddlewarePage;