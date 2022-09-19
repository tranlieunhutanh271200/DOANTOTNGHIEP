import { useRouteMatch } from "react-router-dom";
import { Link, useParams } from "react-router-dom";
import "./grid-course.css";
const courseInit = {
  id: 0,
  title: "",
  coverImageUrl: "",
};
const GridCourseComponent = ({ courses = [courseInit], moveTo = "#", refElement}) => {
  return (
    <div className="courses_component" ref={refElement}>
      {courses.map((course,idx) => (
        <Link
          to={moveTo.replace("{id}", course.id).replace("{classId}", course.classId).replace("{subjectId}", course.subjectId)}
          key={idx}
          className="course"
        >
          <div className="body">
            <div className="course_title">
              <h3>{course.title}</h3>
            </div>
            <div className="course_body">
             
            </div>
            <img src={course.coverImageUrl} alt="" />
            <br></br>
            <h3>{course.code}</h3>
          </div>
        </Link>
      ))}
    </div>
  );
};

export default GridCourseComponent;
