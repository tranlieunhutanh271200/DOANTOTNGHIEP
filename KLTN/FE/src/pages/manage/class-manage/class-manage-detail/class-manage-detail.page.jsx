import { useParams } from "react-router-dom";

const ClassManageDetailPage = () => {
    const {id} = useParams();
    return ( <div>
        This is class manage page for class {id}
    </div> );
}

export default ClassManageDetailPage;