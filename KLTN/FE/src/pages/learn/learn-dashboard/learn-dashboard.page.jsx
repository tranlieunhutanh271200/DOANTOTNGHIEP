import { useParams } from "react-router-dom";
import './learn-dashboard.css';
const LearnDashboardPage = () => {
    const {id} = useParams();
    return ( <div className="learn-dashboard-page">
        This is learn dashboard page
    </div> );
}

export default LearnDashboardPage;