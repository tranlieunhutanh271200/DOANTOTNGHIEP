import { useParams } from "react-router-dom";

const SubjectManageDetailPage = () => {
    const {id} = useParams();
    return (<div>
        This is subject manage detail {id}
    </div>  );
}
export default SubjectManageDetailPage;