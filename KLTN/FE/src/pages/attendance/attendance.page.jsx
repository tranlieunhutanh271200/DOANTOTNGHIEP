import "./attendance.css";
import CalendarComponent from "../../components/calendar/calendar.component";
import { useState } from "react";
import { Typeahead } from "react-bootstrap-typeahead";
import BeautiButtonComponent from "../../components/beauti-button/beauti-button.component";
import { useSelector } from "react-redux";

const AttendancePage = () => {
  const studentData = [
    {
      id: 0,
      fullname: "Trần Anh",
      studentId: "1811001",
      class: "18110CL3A",
      isAvailable: false,
    },
    {
      id: 1,
      fullname: "Trần Anh",
      studentId: "1811002",
      class: "18110CL4A",
      isAvailable: false,
    },
    {
      id: 2,
      fullname: "Trần Anh",
      studentId: "1811003",
      class: "18110CL5A",
      isAvailable: false,
    },
    {
      id: 3,
      fullname: "Trần Anh",
      studentId: "1811004",
      class: "18110CL6A",
      isAvailable: false,
    },
    {
      id: 4,
      fullname: "Trần Anh",
      studentId: "1811005",
      class: "18110CL7A",
      isAvailable: false,
    },
  ];
  const [currentClass, setCurrentClass] = useState(null);
  const [students, setStudents] = useState(studentData);
  const [isLoading, setIsLoading] = useState(false);
  const [singleSelections, setSingleSelections] = useState([]);
  const [currentDay,setCurrentDay] = useState();
  const {role} = useSelector(state => state.auth)
  const markAttendance = (student) => {
    const st = students.find((x) => x.id === student.id);
    st.isAvailable = true;
    setStudents([...students]);
  };
  const markAbsent = (student) => {
    const st = students.find((x) => x.id === student.id);
    st.isAvailable = false;
    setStudents([...students]);
  }
  const save = () => {
    console.log(students);
  };
  return (
    <div className="attendance-page">
      <div className="filter">
        <select className="form-control" onChange={(e) => setCurrentClass(e.target.value)}>
          <option value="0" selected>
            Choose your class
          </option>
          <option value="1">CL3</option>
          <option value="2">CL4</option>
          <option value="3">CLC</option>
        </select>
        <div>
        </div>
      </div>
      <div className="student-list">
        {!currentClass ? (
          "Chon lop de xem thong tin"
        ) : (
          <>
           <Typeahead
          id="basic-typeahead-single"
          labelKey="fullname"
          onChange={setSingleSelections}
          options={studentData.map((st) => 
            `${st.fullname} ${st.studentId}`
          )}
          placeholder="Tim kiem sinh vien..."
          selected={singleSelections}
          className='search'
        />
            <table>
              <thead>
                <tr>
                  <th>STT</th>
                  <th>Ten</th>
                  <th>MSSV</th>
                  <th>Lop</th>
                  <th>Diem danh</th>
                </tr>
              </thead>
              <tbody>
                {students.map((student, idx) => (
                  <tr className="student" key={idx}>
                    <td>{idx + 1}</td>
                    <td>{student.fullname}</td>
                    <td>{student.studentId}</td>
                    <td>{student.class}</td>
                    <td>
                      <BeautiButtonComponent
                        status={student.isAvailable}
                        action={() => markAttendance(student)}
                        rollback={() => markAbsent(student)}
                      ></BeautiButtonComponent>
                    </td>
                  </tr>
                ))}
              </tbody>
              <tfoot>
                <tr>
                  <td>
                    <input type="number" defaultValue={5} /> ngày gần nhất
                  </td>
                </tr>
              </tfoot>
            </table>
            <div className="align-center">
              <button className="btn btn-primary" onClick={save}>
                Lưu <ion-icon name="cloud-download-outline"></ion-icon>
              </button>
              <button className="btn btn-primary" onClick={save}>
                Xuất file <ion-icon name="cloud-download-outline"></ion-icon>
              </button>
            </div>
          </>
        )}
      </div>
    </div>
  );
};

export default AttendancePage;
