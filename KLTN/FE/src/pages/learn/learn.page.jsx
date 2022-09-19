import { useEffect, useState, useRef, useCallback } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import GridCourseComponent from "../../components/grid-course/grid-course.component";
import { loadCustomize } from "../../redux/actions/Customize/customize.action";
import { Collapse } from "react-collapse";
import "./learn.css";
import axiosClient from "../../global/axios/axiosClient";
const timelineData = [
  {
    year: 2022,
    semesters: [],
  },
];
const LearnPage = () => {
  const { location } = useHistory();
  const [filter, setFilter] = useState(new Date().getFullYear());
  const [timeline, setTimeline] = useState([]);
  const [selectedTimeline, setSelectedTimeline] = useState({});
  const [selectedSemester, setSelectedSemester] = useState({});
  const [courses, setCourse] = useState([]);
  const coursesRef = useRef(null);
  const coursesContainerRef = useRef(null);
  const { account, isRefresh } = useSelector((state) => state.auth);
  let isFetch = false;
  useEffect(() => {
    const fetchMasterData = async () => {
      const result = await axiosClient.get(
        `api/course/learn?accountId=${account.id}`
      );
      setTimeline(result.masterdata);
      setCourse(result.masterdata[0].semesters[0].subjects);
      setSelectedTimeline(result.masterdata.find(x => x.year === filter))
      console.log(result);
      isFetch = true;
    };
    fetchMasterData();

  }, [isRefresh]);
  const memorizedFilter = useCallback(() => {
    setSelectedTimeline(
      timeline.find((x) => x.year === filter) ?? timelineData[0]
    );
    setCourse(timeline[0]?.semesters[0]?.subjects ?? []);
  }, [filter]);
  useEffect(() => {
    if (Object.keys(selectedSemester).length > 0) {
      console.log(selectedTimeline.semesters?.find((x) => x.id === selectedSemester?.id));
      setCourse(
        [...selectedTimeline.semesters.find((x) => x.id === selectedSemester?.id)?.subjects]
      );
    }
  }, [selectedSemester, setSelectedSemester]);
  const dispatch = useDispatch();
  const [isCollapsed, setIsCollapsed] = useState(true);
  const toggle = () => {
    setIsCollapsed(!isCollapsed);
  };
  return (
    <div className="learning-page">
      <div className="learning-nav">
        <div className="course-filter">
          {timeline.map((year, idx) => (
            <div className="timeline" key={idx}>
              <button
                className="btn w-100 btn-2x btn-primary"
                onClick={() => setFilter(year.year)}
              >
                {year.year}
              </button>
              <Collapse isOpened={selectedTimeline?.year === year.year}>
                <ul className="semesters">
                  {year.semesters.map((semester, idx) => (
                    <li
                      onClick={() => setSelectedSemester(semester)}
                      className="semester"
                      key={semester.semesterName + idx}
                    >
                      {semester.semesterName}
                    </li>
                  ))}
                </ul>
              </Collapse>
            </div>
          ))}
        </div>
      </div>

      <div className="learning-area" ref={coursesContainerRef}>
        {courses.length > 0 && (
          <GridCourseComponent
            refElement={coursesRef}
            courses={courses.map((x) => {
              const temp = {
                ...x.subject,
                classId: x.id,
                subjectId: x.subjectId,
              };
              return temp;
            })}
            moveTo={`${location.pathname}/{id}/{subjectId}`}
          ></GridCourseComponent>
        )}
      </div>
    </div>
  );
};

export default LearnPage;
