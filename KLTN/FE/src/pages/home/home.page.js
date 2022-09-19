import { useEffect, useRef, useState } from "react";
import { useSelector } from "react-redux";
import { useHistory } from "react-router-dom";
import DashboardCardComponent from "../../components/dashboard-card/dashboard-card.component";
import ScheduleComponent from "../../components/schedule/schedule.component";
import StickyNoteComponent from "../../components/sticky-note/sticky-note.component";
import { ROLE } from "../../consts/role.const";
import "./home.css";
import { isMobile } from "react-device-detect";
import axiosClient from "../../global/axios/axiosClient";
const HomePage = () => {
  const { location } = useHistory();
  const [role, setRole] = useState(ROLE.TEACHER);
  const data = {
    1_2: [
      {
        day: "Monday",
        room: "A5-102",
        subject: "Math",
        period: "1-2",
        time: "7-7:45",
        teacher: "Le Thi Minh Chau",
      },
      {
        day: "Tuesday",
        room: "A5-102",
        subject: "Math",
        period: "1-2",
        time: "7-7:45",
        teacher: "Le Thi Minh Chau",
      },
      {},
      {
        day: "Thursday",
        room: "A5-102",
        subject: "Math",
        period: "1-2",
        time: "7-7:45",
        teacher: "Le Thi Minh Chau",
      },
      {},
      {
        day: "Saturday",
        room: "A5-102",
        subject: "Math",
        period: "1-2",
        time: "7-7:45",
        teacher: "Le Thi Minh Chau",
      },
    ],
    2_3: [
      {
        day: "Monday",
        room: "A5-102",
        subject: "Math",
        period: "1-2",
        time: "7-7:45",
        teacher: "Le Thi Minh Chau",
      },
      {
        day: "Tuesday",
        room: "A5-102",
        subject: "Math",
        period: "1-2",
        time: "7-7:45",
        teacher: "Le Thi Minh Chau",
      },
      {},
      {},
      {},
      {
        day: "Saturday",
        room: "A5-102",
        subject: "Math",
        period: "1-2",
        time: "7-7:45",
        teacher: "Le Thi Minh Chau",
      },
    ],
    3_4: [
      {},
      {
        day: "Tuesday",
        room: "A5-102",
        subject: "Math",
        period: "1-2",
        time: "7-7:45",
        teacher: "Le Thi Minh Chau",
      },
      {},
      {
        day: "Thursday",
        room: "A5-102",
        subject: "Math",
        period: "1-2",
        time: "7-7:45",
        teacher: "Le Thi Minh Chau",
      },
      {},
      {
        day: "Saturday",
        room: "A5-102",
        subject: "Math",
        period: "1-2",
        time: "7-7:45",
        teacher: "Le Thi Minh Chau",
      },
    ],
  };
  const [notes, setNotes] = useState([]);
  const { account } = useSelector((x) => x.auth);
  const [refresh, setRefresh] = useState(false);
  useEffect(() => {
    const fetchData = async () => {
      const result = await axiosClient.get(
        `/api/crm/note?accountId=${
          account?.id || "b36c2a83-aabd-40c3-6b72-08da3503ce41"
        }`
      );
      console.log(result);
      setNotes([...result]);
    };
    fetchData();
  }, [refresh, setRefresh]);
  const saveSticky = async (data) => {
    const putData = {
      id: data.id,
      content: data.content,
      color: data.color,
      xPosition: data.xPosition,
      yPosition: data.yPosition,
    };
    const result = await axiosClient.put(
      `/api/crm/note/${putData.id}`,
      putData
    );
    console.log(result);
  };
  const deleteSticky = async (id) => {
    const result = await axiosClient.delete(`/api/crm/note/${id}`);
    console.log(result);
    if (result) {
      setRefresh(!refresh);
    }
  };
  const addNote = async () => {
    const data = {
      id: 0,
      content: "Note mới của bạn",
      color: "yellow",
      xPosition: 100,
      yPosition: 100,
      accountId: account?.id || "b36c2a83-aabd-40c3-6b72-08da3503ce41",
    };
    const result = await axiosClient.post(
      `/api/crm/note?accountId=${
        account?.id || "b36c2a83-aabd-40c3-6b72-08da3503ce41"
      }`,
      data
    );
    if (result) {
      setRefresh(!refresh);
    }
    console.log(result);
  };
  return (
    <>
      {!isMobile && (
        <>
          {notes.map((note, idx) => (
            <StickyNoteComponent
              key={idx}
              note={note}
              save={saveSticky}
              remove={deleteSticky}
            ></StickyNoteComponent>
          ))}
        </>
      )}
      {/* card */}
      {location.pathname === "/dashboard" && (
        <div>
          <button
            onClick={() => addNote()}
            className="noselect primary text-center ml-2"
          >
            <span className="text">Thêm note</span>
            <span className="icon">
              <ion-icon size="large" name="add-outline"></ion-icon>
            </span>
          </button>
          {/* teacher */}
        </div>
      )}
    </>
  );
};

export default HomePage;
