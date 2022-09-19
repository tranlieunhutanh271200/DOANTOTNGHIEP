import { useEffect, useRef, useState } from "react";
import { useRouteMatch } from "react-router-dom";
import CalendarComponent from "../calendar/calendar.component";
import ScheduleDetailComponent from "./schedule-detail/schedule-detail.component";
import "./schedule.css";
const ScheduleComponent = ({ data }) => {
  const calendarRef = useRef();
  const scheduleRef = useRef();
  const dayRef = useRef();
  const openCalendar = () => {
    calendarRef.current.classList.toggle("hidden");
    scheduleRef.current.classList.toggle("active");
  };
  const dt = new Date();
  const day = dt.getDay();
  // scheduleRef.current?.addEventListener("click", () => {
  //   console.log(scheduleRef.current.classList);
  //   if (scheduleRef.current.classList?.find((c) => c === "active")) {
  //     scheduleRef.current.classList.toggle("active");
  //     calendarRef.current.classList.toggle("hidden");
  //   }
  // });
  const [dayRange,setDayRange] = useState([])
  useEffect(() => {
    dayRef.current.children[day - 1]?.classList.add("today");
  }, []);
  const selectDayRange = (range) => {

  }
  const {path, url} = useRouteMatch();
  return (
    <div className="schedule">
      <div className="title">
        <h3>Your schedule (28/2 - 5/3)</h3>{" "}
       { path !== '/dashboard' && <><span>
          <ion-icon
            onClick={openCalendar}
            size="large"
            name="calendar-outline"
          ></ion-icon>
        </span>
        <div className="calendar hidden" ref={calendarRef}>
          <CalendarComponent></CalendarComponent>
        </div></> }
      </div>
      <table ref={scheduleRef}>
        <thead>
          <tr ref={dayRef}>
            <td>Monday</td>
            <td>Tuesday</td>
            <td>Wednesday</td>
            <td>Thursday</td>
            <td>Friday</td>
            <td>Saturday</td>
          </tr>
        </thead>
        <tbody>
          {Object.keys(data).map((key, idx) => 
              <tr key={key}>
                {data[key].map((row, i) => (
                  <td key={i}>{<ScheduleDetailComponent data={row}/>}</td>
                ))}
              </tr>
            )
          }
        </tbody>
      </table>
      {Object.keys(data).length > 2 && (
        <div className="table_showmore">
          <button>
            <ion-icon
              size="large"
              name="chevron-down-circle-outline"
            ></ion-icon>{" "}
          </button>
        </div>
      )}
    </div>
  );
};

export default ScheduleComponent;
