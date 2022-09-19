import { Link, useHistory } from "react-router-dom";
import "./exam-script.css";
const ExamScriptComponent = ({ exam, isModifiable, remove }) => {
  const {location} = useHistory();
  return (
    <>
      <div className={isModifiable ? "edit-mode" : ""}>
        <Link className="no-decoration" to={`${location.pathname}/exam/${1}`}>
          <div className="exam-script">
            <h3>{exam.title}</h3>
            {exam.description}
          </div>
        </Link>
        {isModifiable && (
          <div className="remove">
            <ion-icon
              size="large"
              onClick={() => remove(exam)}
              name="trash-outline"
            ></ion-icon>
          </div>
        )}
      </div>
    </>
  );
};

export default ExamScriptComponent;
