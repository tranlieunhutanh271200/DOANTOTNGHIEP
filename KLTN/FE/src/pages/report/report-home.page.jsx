import { Link, useHistory } from "react-router-dom";
import './report.page.css'
const ReportHomePage = () => {
    const {location} = useHistory();
    return ( <div className="report-home">
        this is report home page
        <Link to={`${location.pathname}/project`}>project report</Link>
        <br>
        </br>
        <Link to={`${location.pathname}/ticket`}>ticket report</Link>
        <br></br>
        <Link to={`${location.pathname}/class`}>Class report</Link>
        <br></br>
    </div> );
}

export default ReportHomePage;