import { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { useParams } from "react-router-dom";
import { Redirect } from "react-router-dom";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import "./calendar.css";
import "react-responsive-modal/styles.css";
import { Modal } from "react-responsive-modal";
import { ROLE } from "../../consts/role.const";
import { useSelector } from "react-redux";
const CalendarComponent = ({
  isSelectRangeEnable = true,
  selectRange,
  selectDay,
  isAddEventEnable = false,
  addEvent,
  events = [],
  type = 1
}) => {
  const { account } = useSelector((x) => x.auth);
  var dt = new Date();
  var month = dt.getMonth();
  var year = dt.getFullYear();
  let history = useHistory();
  const [localEvents, setLocalEvents] = useState(events);
  // useEffect(() => {
  //   setLocalEvents([...events]);
  // }, [events]);
  const { id } = useParams();
  const [currentMonth, setCurrentMonth] = useState(month + 1);
  const [range, setRange] = useState([]);
  const [isPress, setIspress] = useState(false);
  var daysInMonth = new Date(year, currentMonth, 0).getDate();
  const [day, setDay] = useState(dt.getDate());
  const monthChange = (isIncrease) => {
    let thisMonth = currentMonth;
    if (isIncrease) {
      setCurrentMonth(currentMonth < 12 ? (thisMonth += 1) : 1);
    } else {
      setCurrentMonth(currentMonth > 1 ? (thisMonth -= 1) : 12);
    }
  };
  const fillRange = (start, stop) => {
    let arr = [];
    if (start < stop) {
      for (let i = start + 1; i <= stop; i++) {
        arr.push(i);
      }
    } else {
      for (let i = stop; i < start; i++) {
        arr.push(i);
      }
    }
    return arr;
  };
  const reset = () => {
    setCurrentMonth(month + 1);
  };
  const select = (index) => {
    setIspress(true);
    if (range.length === 0) {
      setRange([...range, index]);
    } else {
      setRange([index]);
    }
  };
  const move = (index) => {
    if (isPress) {
      let temp = fillRange(range[0], index);
      setRange([...range, ...temp]);
    }
  };
  const release = (index) => {
    setRange([...range, index]);
    setIspress(false);
  };
  const submit = (e) => {
    e.preventDefault();
    if (range.length > 1) {
      if (selectRange) {
        selectRange(range);
      }
    } else {
      if (selectDay) {
        selectDay(range[0]);
      }
    }
  };
  const [eventModal, setEventModal] = useState(false);
  const toggleEventModal = () => {
    setEventModal(!eventModal);
  };
  return (
    <div className="calendar_group">
      <div className="indicator">
        <div>
          <ion-icon
            onClick={() => monthChange(false)}
            name="chevron-back-outline"
          ></ion-icon>
        </div>
        <label onClick={reset}>
          {currentMonth} / {year}
        </label>
        <div>
          <ion-icon
            onClick={() => monthChange(true)}
            name="chevron-forward-outline"
          ></ion-icon>
        </div>
      </div>
      <div className="days">
        {[...Array(daysInMonth).keys()].map((val) =>
          isSelectRangeEnable ? (
            <div
              key={val}
              onMouseDown={() => select(val + 1)}
              onMouseEnter={() => move(val + 1)}
              onMouseUp={() => release(val + 1)}
              className={`day select ${
                val + 1 === day && month + 1 === currentMonth ? "today" : ""
              } ${
                range.find((r) => r === val + 1) !== undefined ? "inrange" : ""
              }`}
            >
              {val + 1}
            </div>
          ) : (
            <div
              key={val}
              onClick={() => {
                setDay(val + 1);
              }}
              onDoubleClick={() => {
                if (account) {
                  toggleEventModal();
                }
              }}
              className={`day ${
                val + 1 === day && month + 1 === currentMonth ? "today" : ""
              } ${
                range.find((r) => r === val + 1) !== undefined ? "inrange" : ""
              } ${
                localEvents.find(
                  (x) =>
                    x.day === val + 1 &&
                    x.month === currentMonth &&
                    x.year === year
                )?.absoluteDate > dt.getTime()
                  ? "event-day"
                  : ""
              }`}
            >
              {val + 1}
            </div>
          )
        )}
      </div>
      {isSelectRangeEnable && (
        <div className="footer">
          <button onClick={(e) => submit(e)}>Select</button>
        </div>
      )}

      <Modal
        classNames={{ modal: "center large-modal glass-modal " }}
        open={eventModal}
        onClose={toggleEventModal}
      >
        <div className="event-box">
          <h3>Danh sách sự kiện</h3>
          {events.filter(x => x.day === day).map((event, idx) => (
            <div className="event" key={idx}>
              {event.title && <h3>{event.title}</h3>}
              <p>Mô tả: {event.detail}</p>
              <p>Hạn chót: {event.due}</p>
            </div>
          ))}
        </div>
        {account && account.role === ROLE.TEACHER && (
          <div className="add-event-box">
            <label>
              Thêm sự kiện cho lớp {"17110221"} vào ngày {day}/{month + 1}/
              {year}
            </label>
            <input className="form-field" placeholder="Tiêu đề" />
            <input className="form-field" placeholder="Mô tả" />
            <select defaultValue={""} className="form-field">
              <option value="">Chọn loại sự kiện</option>
              <option value="exam">Kiểm tra</option>
              <option value="online-meeting">Học online</option>
            </select>
            <input type="time" className="form-field" />
            input
            <div className="align-center">
              <button className="btn btn-primary">
                <ion-icon size="large" name="add-outline"></ion-icon>
              </button>
            </div>
          </div>
        )}
      </Modal>
    </div>
  );
};

export default CalendarComponent;
