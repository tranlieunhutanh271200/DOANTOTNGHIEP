import "./schedule-detail.css";
const ScheduleDetailComponent = ({ data }) => {
  return (
    <>
      <div className="card_schedule">
        {Object.keys(data).length > 0 && (
          <>
            <div className="title">
              <h3>{data.subject}</h3>{" "}
              <span>
                <ion-icon name="bookmark-outline"></ion-icon>
              </span>
            </div>
            <div className="body">
              <h4>Time: {data.time}</h4>
              <h5>Tiết: {data.period}</h5>
              <h5>Phòng: {data.room}</h5>
              <h4>GV: {data.teacher}</h4>
            </div>
          </>
        )}
      </div>
    </>
  );
};

export default ScheduleDetailComponent;
