import "./domain-manage.css";
import Tabs, { Tab } from "react-best-tabs";
import "react-best-tabs/dist/index.css";
import DynamicTable from "@atlaskit/dynamic-table";
import Columns from "react-columns";
import { useEffect, useState } from "react";
import ImageUpload from "image-upload-react";
import connection from "../../../services/signalr.service";
import { CompactTable } from "@table-library/react-table-library/compact";
import { connect, useSelector } from "react-redux";
import DataTableComponent from "../../../components/datatable/datatable.component";
import { ACTION } from "../../../consts/action.const";
import axiosClient from "../../../global/axios/axiosClient";
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";
import CheckListComponent from "../../../components/checklist/checklist.component";
const SelfDomainManage = () => {
  const [domain, setDomain] = useState({
    domain: {},
    teachers: [
      {
        id: "b70d4057-ee17-4ff8-9e18-08da3503ccc0",
        fullName: "Lê Thị Minh Châu",
        teacherID: "IT100001",
        permanentAddress: "TP.HCM",
        identityNo: "888888888888",
        phoneNumber: "",
        currentAddress: "TP.HCM",
        birthDate: "1/1/0001 12:00:00 AM",
        joinDate: "1/1/0001 12:00:00 AM",
        domainId: "b70d4057-ee17-4ff8-9e18-08da3503ccc0",
      },
      {
        id: "b70d4057-ee17-4ff8-9e18-08da3503ccc0",
        fullName: "Nguyễn Trần Thi Văn",
        teacherID: "IT100002",
        permanentAddress: "TP.HCM",
        identityNo: "888888888888",
        phoneNumber: "",
        currentAddress: "TP.HCM",
        birthDate: "1/1/0001 12:00:00 AM",
        joinDate: "1/1/0001 12:00:00 AM",
        domainId: "b70d4057-ee17-4ff8-9e18-08da3503ccc0",
      },
    ],
    students: [],
    classes: [
      {
        id: "ea75d09e-1fcc-4855-57b3-08da362d877b",
        className: "18110CL3",
        town: "A",
        floor: "Lau 2",
        room: "A1-401",
        domainId: "b70d4057-ee17-4ff8-9e18-08da3503ccc0",
      },
      {
        id: "55984279-1ff0-47f3-8e6e-08da415c3141",
        className: "Hello",
        town: "Hello",
        floor: "Hello",
        room: "Hello",
        domainId: "b70d4057-ee17-4ff8-9e18-08da3503ccc0",
      },
    ],
    semesters: [
      {
        subjects: [],
        id: 1,
        domainId: "b70d4057-ee17-4ff8-9e18-08da3503ccc0",
        year: 2022,
        semesterName: "Học kỳ 1",
        semesterStart: "15-05-2022",
        semesterEnd: "15-10-2022",
      },
    ],
    subjects: [],
  });
  const { account, isRefresh } = useSelector((x) => x.auth);
  const [refresh, setRefresh] = useState(false);
  const [addTeacher, setAddTeacher] = useState({});
  const [addStudent, setAddStudent] = useState({});
  const [addSemester, setAddSemester] = useState({});
  const [addClass, setAddClass] = useState({
    students: [],
  });
  useEffect(() => {
    //Calling api here
    const fetchData = async () => {
      var result = await axiosClient.get(
        `/api/course?domainId=${account.domain.id}`
      );
      console.log(result.subjects.subjects);
      setDomain({
        ...domain,
        domain: result.domain,
        students: result.students.students,
        teachers: result.teachers.teachers,
        semesters: result.semesters.semesters,
        classes: result.classes.classes,
        subjects: result.subjects.subjects,
      });
      setAddClass({
        ...addClass,
        semesterId: result.semesters.semesters[0]?.id,
        teacherId: result.teachers.teachers[0]?.id,
        subjectId: result.subjects.subjects[0]?.id
      })
    };
    fetchData();
  }, [isRefresh, refresh]);
  const [imageSrc, setImageSrc] = useState();
  const handleImageSelect = (e) => {
    console.log(e.target.files[0]);
    setImageSrc(URL.createObjectURL(e.target.files[0]));
  };
  const COLUMNS = [
    { label: "Họ và tên", renderCell: (item) => item.fullName },

    { label: "Mã GV", renderCell: (item) => item.teacherID },
    {
      label: "Địa chỉ thường trú",
      renderCell: (item) => item.permanentAddress,
    },
    { label: "ID", renderCell: (item) => item.identityNo },
    {
      label: "Ngày sinh",
      renderCell: (item) =>
        item.birthDate.toLocaleDateString("en-US", {
          year: "numeric",
          month: "2-digit",
          day: "2-digit",
        }),
    },
  ];
  const row = [
    {
      fullName: "Lê Thị Minh Châu",
      teacherID: "IT100001",
      permanentAddress: "TP.HCM",
      identityNo: "888888888888",
      phoneNumber: "",
      currentAddress: "TP.HCM",
      birthDate: "1/1/0001 12:00:00 AM",
      joinDate: "1/1/0001 12:00:00 AM",
      domainId: "b70d4057-ee17-4ff8-9e18-08da3503ccc0",
    },
  ];
  const data = { row };
  const [isOpen, setIsOpen] = useState(false);
  const [type, setType] = useState("teacher");
  const [action, setAction] = useState("");
  useEffect(() => {
    if (action !== "") {
      console.log("wtf");
      setIsOpen(true);
    } else {
      setIsOpen(false);
    }
  }, [action]);

  const [currentTeacher, setCurrentTeacher] = useState({});
  const [currentStudent, setCurrentStudent] = useState({});
  const [currentClass, setCurrentClass] = useState({});
  const [currentSubject, setCurrentSubject] = useState({});
  const [currentSemester, setCurrentSemester] = useState({});
  const toggleModal = () => {
    if (action !== "") {
      setAction("");
    }
    setIsOpen(!isOpen);
  };

  const toggleStudent = (student) => {
    if (addClass.students.find((x) => x.id === student.id)) {
      setAddClass({
        ...addClass,
        students: [...addClass.students.filter((x) => x.id !== student.id)],
      });
    } else {
      setAddClass({ ...addClass, students: [...addClass.students, student] });
    }
  };
  const toggleStudent2 = (student) => {
    console.log(currentClass);
    if (currentClass.students.find((x) => x.id === student.id)) {
      console.log("cc");
      setCurrentClass({
        ...currentClass,
        students: [...currentClass.students.filter((x) => x.id !== student.id)],
      });
    } else {
      console.log("dkm");
      setCurrentClass({ ...currentClass, students: [...currentClass.students, student] });
    }
  };
  const addTeacherValueChange = (e) => {
    setAddTeacher({
      ...addTeacher,
      [e.target.name]: e.target.value,
    });
  };
  const addStudentValueChange = (e) => {
    setAddStudent({
      ...addStudent,
      [e.target.name]: e.target.value,
    });
  };
  const updateStudentValueChange = (e) => {
    setCurrentStudent({
      ...currentStudent,
      [e.target.name]: e.target.value,
    });
  };
  const updateTeacherValueChange = (e) => {
    setCurrentTeacher({
      ...currentTeacher,
      [e.target.name]: e.target.value,
    });
  };
  const addSemesterValueChange = (e) => {
    setAddSemester({
      ...addSemester,
      [e.target.name]: e.target.value,
    });
  };
  const updateSemesterValueChange = (e) => {
    setCurrentSemester({
      ...currentSemester,
      [e.target.name]: e.target.value,
    });
  };
  const [addSubject, setAddSubject] = useState({});

  const addSubjectValueChange = (e) => {
    setAddSubject({
      ...addSubject,
      [e.target.name]: e.target.value,
    });
  };
  const updateSubjectValueChange = (e) => {
    setCurrentSubject({
      ...currentSubject,
      [e.target.name]: e.target.value,
    });
  };
  const submit = async () => {
    let refreshNow = false;
    switch (action) {
      case ACTION.ADDTEACHER:
        console.log(addTeacher);
        const data = {
          ...addTeacher,
          domainId: account.domain.id,
          action: 1,
        };
        var createResult = await axiosClient.post("/api/Course/teachers", data);
        console.log(createResult);
        console.log(data);
        if (createResult.status === 200) {
          refreshNow = true;
        }
        setAddTeacher({});
        break;
      case ACTION.EDITTEACHER:
        const editdata = {
          ...currentTeacher,
          action: 2,
          joinDate: "2022-05-29",
        };
        console.log(editdata);
        var updateResult = await axiosClient.post(
          "/api/Course/teachers",
          editdata
        );
        if (updateResult.status === 200) {
          refreshNow = true;
        }
        console.log(updateResult);
        break;
      case ACTION.DELETETEACHER:
        const deleteData = {
          ...currentTeacher,
          action: 3,
          joinDate: "2022-05-29",
        };
        var deleteResult = await axiosClient.post(
          "/api/Course/teachers",
          deleteData
        );
        console.log(deleteResult);
        console.log(deleteData);
        if (deleteResult.status === 200) {
          refreshNow = true;
        }
        break;
      case ACTION.ADDSTUDENT:
        const addStudentData = {
          ...addStudent,
          action: 1,
          domainId: account.domain.id,
        };
        createResult = await axiosClient.post(
          "/api/Course/students",
          addStudentData
        );
        if (createResult.status === 200) {
          refreshNow = true;
        }
        console.log(createResult);
        setAddStudent({});
        break;
      case ACTION.EDITSTUDENT:
        const updateStudentData = {
          ...currentStudent,
          action: 2,
        };
        createResult = await axiosClient.post(
          "/api/Course/students",
          updateStudentData
        );
        if (createResult.status === 200) {
          refreshNow = true;
        }
        console.log(createResult);
        break;
      case ACTION.DELETESTUDENT:
        const deleteStudentData = {
          ...currentStudent,
          action: 3,
        };
        createResult = await axiosClient.post(
          "/api/Course/students",
          deleteStudentData
        );
        if (createResult.status === 200) {
          refreshNow = true;
        }
        console.log(createResult);
        break;
      case ACTION.ADDSEMESTER:
        console.log(addSemester);
        const createSemesterData = {
          action: 1,
          ...addSemester,
          year: new Date().getFullYear(),
          domainId:
            account?.domain?.id || "b70d4057-ee17-4ff8-9e18-08da3503ccc0",
        };
        const createSemesterResult = await axiosClient.post(
          `/api/course/semester`,
          createSemesterData
        );
        if (createSemesterResult.status === 200) {
          refreshNow = true;
        }
        console.log(createSemesterResult);
        setAddSemester({});
        break;
      case ACTION.UPDATESEMESTER:
        console.log(currentSemester);
        const updateSemesterData = {
          action: 2,
          ...currentSemester,
        };
        const updateSemesterResult = await axiosClient.post(
          `/api/course/semester`,
          updateSemesterData
        );
        if (updateSemesterResult.status === 200) {
          refreshNow = true;
        }
        console.log(updateSemesterResult);
        break;
      case ACTION.DELETESEMESTER:
        console.log(currentSemester);
        const deleteSemesterData = {
          action: 3,
          ...currentSemester,
        };
        const deleteSemesterResult = await axiosClient.post(
          `/api/course/semester`,
          deleteSemesterData
        );
        if (deleteSemesterResult.status === 200) {
          refreshNow = true;
        }
        console.log(deleteSemesterResult);
        break;
      case ACTION.ADDSUBJECT:
        console.log(addSubject);
        const addSubjectData = {
          ...addSubject,
          action: 1,
          domainId: account.domain.id,
        };
        var result = await axiosClient.post(
          "/api/course/subjects",
          addSubjectData
        );
        if (result.status === 200) {
          refreshNow = true;
        }
        console.log(result);
        setAddSubject({});
        break;
      case ACTION.UPDATESUBJECT:
        console.log(currentSubject);
        const updateSubjectData = {
          ...currentSubject,
          action: 2,
          domainId: account.domain.id,
        };
        var result = await axiosClient.post(
          "/api/course/subjects",
          updateSubjectData
        );
        console.log(result);
        if (result.status === 200) {
          refreshNow = true;
        }
        break;
      case ACTION.DELETESUBJECT:
        console.log(currentSubject);
        const deleteSubjectData = {
          ...currentSubject,
          action: 3,
        };
        var result = await axiosClient.post(
          "/api/course/subjects",
          deleteSubjectData
        );
        if (result.status === 200) {
          refreshNow = true;
        }
        console.log(result);
        break;
      case ACTION.ADDCLASS:
        console.log(addClass);
        const createClass = {
          ...addClass,
          action: 1
        }
        var createResult = await axiosClient.post("/api/course/classes", createClass);
        if(createResult.status === 200){
          refreshNow = true;
        }
        setAddClass({
          ...addClass,
          semesterId: domain.semesters[0]?.id,
          teacherId: domain.teachers[0]?.id,
          subjectId: domain.subjects[0]?.id,
          students: []
        })
        break;
      case ACTION.UPDATECLASS:
        console.log(currentClass);
        const updateClass = {
          ...currentClass,
          action: 2
        }
        var createResult = await axiosClient.post("/api/course/classes", updateClass);
        if(createResult.status === 200){
          refreshNow = true;
        }
        setCurrentClass({});
        break;
      case ACTION.DELETECLASS:
        const deleteClass = {
          ...currentClass,
          action: 3
        }
        var createResult = await axiosClient.post("/api/course/classes", deleteClass);
        if(createResult.status === 200){
          refreshNow = true;
        }
        setCurrentClass({});
        break;
      default:
        break;
    }
    if (refreshNow) {
      setRefresh(!refresh);
    }
    setAction("");
  };
  return (
    <div className="self-domain-page">
      <Tabs
        activeTab="1"
        className="mt-5"
        ulClassName=""
        activityClassName="bg-success"
      >
        <Tab title="Thông tin tổng quan">
          <Columns columns={2}>
            <div>
              <form>
                <div className="form-group">
                  <label htmlFor="">Tên trường</label>
                  <input
                    defaultValue={domain.domain.schoolName}
                    type="text"
                    className="form-field"
                    disabled
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="">Tên viết tắt</label>
                  <input
                    defaultValue={domain.domain.abbreviation}
                    type="text"
                    className="form-field"
                    disabled
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="">Địa chỉ</label>
                  <input
                    defaultValue={domain.domain.schoolAddress}
                    type="text"
                    className="form-field"
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="">Website trường</label>
                  <input
                    defaultValue={domain.domain.schoolUrl}
                    type="text"
                    className="form-field"
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="">Email trường</label>
                  <input
                    defaultValue={domain.domain.schoolEmail}
                    type="text"
                    className="form-field"
                  />
                </div>
              </form>
            </div>
            <div>
              <form>
                <div
                  className="form-group"
                  style={{ height: "200px", width: "200px" }}
                >
                  <label>Logo trường</label>
                  <img className="img-box" src="/img/school-logo.png" alt="" />
                  <ImageUpload
                    handleImageSelect={handleImageSelect}
                    imageSrc={imageSrc}
                    setImageSrc={setImageSrc}
                    style={{
                      width: 300,
                      height: 200,
                      background: "gold",
                    }}
                  />
                </div>
              </form>
            </div>
          </Columns>
          <div className="align-center">
            <button className="noselect primary">
              <span className="text">Lưu</span>
              <span className="icon">
                <ion-icon size="large" name="save-outline"></ion-icon>
              </span>
            </button>
          </div>
        </Tab>
        <Tab title="Học kỳ" className="mr-3">
          <DataTableComponent
            rows={domain.semesters}
            headers={[
              "Năm",
              "Tên học kỳ",
              "Ngày bắt đầu",
              "Ngày kết thúc",
              "Số lớp",
            ]}
            hideColumns={["id", "domainId", "subjects"]}
            isAddable={true}
            isEditable={true}
            isDeleteable={true}
            openAddModal={() => setAction(ACTION.ADDSEMESTER)}
            openEditModal={(e) => {
              setAction(ACTION.UPDATESEMESTER);
              setCurrentSemester(e);
            }}
            openDeleteModal={(e) => {
              setAction(ACTION.DELETESEMESTER);
              setCurrentSemester(e);
            }}
          ></DataTableComponent>
        </Tab>
        <Tab title="Giảng viên/Giáo viên" className="mr-3">
          <DataTableComponent
            rows={domain.teachers}
            headers={[
              "Họ và tên",
              "Mã GV",
              "Địa chỉ TT",
              "CMND/CCCD",
              "SĐT",
              "Địa chỉ",
              "Ngày sinh",
            ]}
            hideColumns={["joinDate", "domainId", "id"]}
            isAddable={true}
            isDeleteable={true}
            isEditable={true}
            openAddModal={() => setAction(ACTION.ADDTEACHER)}
            openEditModal={(e) => {
              setAction(ACTION.EDITTEACHER);
              setCurrentTeacher(e);
            }}
            openDeleteModal={(e) => {
              setAction(ACTION.DELETETEACHER);
              setCurrentTeacher(e);
            }}
          ></DataTableComponent>
        </Tab>

        <Tab title="Học sinh/Sinh viên" className="mr-3">
          <DataTableComponent
            rows={domain.students}
            headers={[
              "Họ và tên",
              "Mã SV",
              "Địa chỉ TT",
              "CMND/CCCD",
              "SĐT",
              "Địa chỉ",
              "Ngày sinh",
            ]}
            hideColumns={["joinDate", "domainId", "id", "accountId"]}
            isAddable={true}
            isDeleteable={true}
            isEditable={true}
            openAddModal={() => setAction(ACTION.ADDSTUDENT)}
            openEditModal={(e) => {
              setAction(ACTION.EDITSTUDENT);
              setCurrentStudent(e);
            }}
            openDeleteModal={(e) => {
              setAction(ACTION.DELETESTUDENT);
              setCurrentStudent(e);
            }}
          ></DataTableComponent>
        </Tab>
        <Tab title="Lớp học" className="mr-3">
          <DataTableComponent
            rows={domain.classes}
            headers={["Giảng viên", "Mã lớp", "Số lượng HS/SV"]}
            hideColumns={[
              "id",
              "students",
              "subject",
              "subjectId",
              "teacherId",
              "semesterId",
            ]}
            isAddable={true}
            isDeleteable={true}
            isEditable={true}
            customizeColumns={[
              {
                header: "Môn học",
                body: (row) => <>{row.subject?.title}</>,
              },
            ]}
            openAddModal={() => setAction(ACTION.ADDCLASS)}
            openEditModal={(e) => {
              setCurrentClass(e);
              setAction(ACTION.UPDATECLASS);
            }}
            openDeleteModal={(e) => {
              setCurrentClass(e);
              setAction(ACTION.DELETECLASS);
            }}
          ></DataTableComponent>
        </Tab>
        <Tab title="Môn học" className="mr-3">
          <DataTableComponent
            rows={domain.subjects}
            headers={["Tên môn học", "Cover", "Mô tả", "Số tiết", "Mã môn"]}
            hideColumns={["id", "pricePerCredit", "teacherSubjects"]}
            imageColumns={["coverImageUrl"]}
            isAddable={true}
            isDeleteable={true}
            isEditable={true}
            openAddModal={() => setAction(ACTION.ADDSUBJECT)}
            openEditModal={(e) => {
              setAction(ACTION.UPDATESUBJECT);
              setCurrentSubject(e);
            }}
            openDeleteModal={(e) => {
              setAction(ACTION.DELETESUBJECT);
              setCurrentSubject(e);
            }}
            customizeColumns={[
              {
                header: "Cấu hình",
                body: (row) => (
                  <div className="align-center">
                    <button
                      onClick={() => {
                        setCurrentSubject(row);
                        setAction(ACTION.ASSIGNMENT);
                      }}
                      className="noselect primary"
                    >
                      <span className="text">Giảng dạy</span>
                      <span className="icon">
                        <ion-icon size="large" name="create-outline"></ion-icon>
                      </span>
                    </button>
                  </div>
                ),
              },
            ]}
          ></DataTableComponent>
        </Tab>
      </Tabs>
      <ModalTransition>
        {isOpen && (
          <Modal onClose={toggleModal}>
            <ModalHeader>
              <ModalTitle>
                {action === ACTION.ADDTEACHER && "Thêm GV"}
                {action === ACTION.EDITTEACHER && "Cập nhật GV"}
                {action === ACTION.DELETETEACHER && "Xóa GV"}

                {action === ACTION.ADDSTUDENT && "Thêm HS/SV"}
                {action === ACTION.EDITSTUDENT && "Cập nhật HS/SV"}
                {action === ACTION.DELETESTUDENT && "Xóa HS/SV"}

                {action === ACTION.ADDSEMESTER && "Thêm học kì"}
                {action === ACTION.UPDATESEMESTER && "Chỉnh sửa học kì"}
                {action === ACTION.DELETESEMESTER && "Xóa học kì"}

                {action === ACTION.ADDCLASS && "Thêm lớp học"}
                {action === ACTION.UPDATECLASS && "Chỉnh sửa lớp học"}
                {action === ACTION.DELETECLASS && "Xóa lớp học"}

                {action === ACTION.ADDSUBJECT && "Thêm môn học"}
                {action === ACTION.UPDATESUBJECT && "Chỉnh sửa môn học"}
                {action === ACTION.DELETESUBJECT && "Xóa môn học"}
              </ModalTitle>
            </ModalHeader>
            <ModalBody>
              <form>
                {action === ACTION.ADDTEACHER && (
                  <>
                    <div className="form-group">
                      <label htmlFor="">Họ và tên</label>
                      <input
                        className="form-field"
                        type="text"
                        name="fullname"
                        onChange={(e) => addTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Mã GV</label>
                      <input
                        className="form-field"
                        type="text"
                        name="teacherID"
                        onChange={(e) => addTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Địa chỉ thường trú</label>
                      <input
                        className="form-field"
                        type="text"
                        name="permanentAddress"
                        onChange={(e) => addTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">CMND/CCCD</label>
                      <input
                        className="form-field"
                        type="text"
                        name="identityNo"
                        onChange={(e) => addTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">SĐT</label>
                      <input
                        className="form-field"
                        type="text"
                        name="phoneNumber"
                        onChange={(e) => addTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Địa chỉ hiện tại</label>
                      <input
                        className="form-field"
                        type="text"
                        name="currentAddress"
                        onChange={(e) => addTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Ngày sinh</label>
                      <input
                        className="form-field"
                        type="date"
                        name="birthDate"
                        onChange={(e) => addTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Ngày tham gia</label>
                      <input
                        className="form-field"
                        type="date"
                        name="joinDate"
                        onChange={(e) => addTeacherValueChange(e)}
                      />
                    </div>
                  </>
                )}
                {action === ACTION.EDITTEACHER && (
                  <>
                    <div className="form-group">
                      <label htmlFor="">Họ và tên</label>
                      <input
                        defaultValue={currentTeacher.fullName}
                        className="form-field"
                        type="text"
                        name="fullname"
                        onChange={(e) => updateTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Địa chỉ thường trú</label>
                      <input
                        defaultValue={currentTeacher.permanentAddress}
                        className="form-field"
                        type="text"
                        name="permanentAddress"
                        onChange={(e) => updateTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">CMND/CCCD</label>
                      <input
                        defaultValue={currentTeacher.identityNo}
                        className="form-field"
                        type="text"
                        name="identityNo"
                        onChange={(e) => updateTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">SĐT</label>
                      <input
                        defaultValue={currentTeacher.phoneNumber}
                        className="form-field"
                        type="text"
                        name="phoneNumber"
                        onChange={(e) => updateTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Địa chỉ hiện tại</label>
                      <input
                        defaultValue={currentTeacher.currentAddress}
                        className="form-field"
                        type="text"
                        name="currentAddress"
                        onChange={(e) => updateTeacherValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Ngày sinh</label>
                      <input
                        defaultValue={currentTeacher.birthDate}
                        className="form-field"
                        type="date"
                        name="birthDate"
                        onChange={(e) => updateTeacherValueChange(e)}
                      />
                    </div>
                  </>
                )}
                {action === ACTION.DELETETEACHER && (
                  <h3>
                    Bạn có chắc muốn xóa thông tin giáo viên/giảng viên này
                  </h3>
                )}
                {action === ACTION.ADDSTUDENT && (
                  <>
                    <div className="form-group">
                      <label htmlFor="">Họ và tên</label>
                      <input
                        className="form-field"
                        type="text"
                        name="fullname"
                        onChange={(e) => addStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Địa chỉ thường trú</label>
                      <input
                        className="form-field"
                        type="text"
                        name="permanentAddress"
                        onChange={(e) => addStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">CMND/CCCD</label>
                      <input
                        className="form-field"
                        type="text"
                        name="identityNo"
                        onChange={(e) => addStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">SĐT</label>
                      <input
                        className="form-field"
                        type="text"
                        name="phoneNumber"
                        onChange={(e) => addStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Địa chỉ hiện tại</label>
                      <input
                        className="form-field"
                        type="text"
                        name="currentAddress"
                        onChange={(e) => addStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Ngày sinh</label>
                      <input
                        className="form-field"
                        type="date"
                        name="birthDate"
                        onChange={(e) => addStudentValueChange(e)}
                      />
                    </div>
                  </>
                )}
                {action === ACTION.EDITSTUDENT && (
                  <>
                    <div className="form-group">
                      <label htmlFor="">Họ và tên</label>
                      <input
                        defaultValue={currentStudent.fullName}
                        className="form-field"
                        type="text"
                        name="fullname"
                        onChange={(e) => updateStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Mã HS/SV</label>
                      <input
                        defaultValue={currentStudent.studentID}
                        className="form-field"
                        type="text"
                        name="studentID"
                        maxLength={12}
                        onChange={(e) => updateStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Địa chỉ thường trú</label>
                      <input
                        defaultValue={currentStudent.permanentAddress}
                        className="form-field"
                        type="text"
                        name="permanentAddress"
                        onChange={(e) => updateStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">CMND/CCCD</label>
                      <input
                        defaultValue={currentStudent.identityNo}
                        className="form-field"
                        type="text"
                        name="identityNo"
                        onChange={(e) => updateStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">SĐT</label>
                      <input
                        defaultValue={currentStudent.phoneNumber}
                        className="form-field"
                        type="text"
                        name="phoneNumber"
                        onChange={(e) => updateStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Địa chỉ hiện tại</label>
                      <input
                        defaultValue={currentStudent.currentAddress}
                        className="form-field"
                        type="text"
                        name="currentAddress"
                        onChange={(e) => updateStudentValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Ngày sinh</label>
                      <input
                        defaultValue={currentStudent.birthDate}
                        className="form-field"
                        type="date"
                        name="birthDate"
                        onChange={(e) => updateStudentValueChange(e)}
                      />
                    </div>
                  </>
                )}
                {action === ACTION.DELETESTUDENT && (
                  <h3>
                    Bạn có chắc muốn xóa thông tin học sinh/sinh viên này?
                  </h3>
                )}
                {action === ACTION.ADDSEMESTER && (
                  <>
                    <div className="form-group">
                      <label htmlFor="">Tên học kì</label>
                      <input
                        className="form-field"
                        type="text"
                        name="semesterName"
                        onChange={(e) => addSemesterValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Ngày bắt đầu</label>
                      <input
                        className="form-field"
                        type="date"
                        name="semesterStart"
                        min={new Date().toISOString().substring(0, 10)}
                        max="2030-12-31"
                        onChange={(e) => addSemesterValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Ngày kết thúc</label>
                      <input
                        className="form-field"
                        type="date"
                        name="semesterEnd"
                        placeholder="dd-mm-yyyy"
                        min={new Date().toISOString().substring(0, 10)}
                        max="2030-12-31"
                        onChange={(e) => addSemesterValueChange(e)}
                      />
                    </div>
                  </>
                )}
                {action === ACTION.UPDATESEMESTER && (
                  <>
                    <div className="form-group">
                      <label htmlFor="">Tên học kì</label>
                      <input
                        defaultValue={currentSemester.semesterName}
                        className="form-field"
                        type="text"
                        name="semesterName"
                        onChange={(e) => updateSemesterValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Ngày bắt đầu</label>
                      <input
                        className="form-field"
                        type="date"
                        name="semesterStart"
                        defaultValue={currentSemester.semesterStart}
                        onChange={(e) => updateSemesterValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Ngày kết thúc</label>
                      <input
                        className="form-field"
                        type="date"
                        name="semesterEnd"
                        defaultValue={currentSemester.semesterEnd}
                        onChange={(e) => updateSemesterValueChange(e)}
                      />
                    </div>
                  </>
                )}
                {action === ACTION.DELETESEMESTER && (
                  <h3>
                    Bạn có chắc muốn xóa học kì này không, các thông tin liên
                    quan học kì này sẽ mất?
                  </h3>
                )}
                {action === ACTION.ADDSUBJECT && (
                  <>
                    <div className="form-group">
                      <label htmlFor="">Mã môn</label>
                      <input
                        type="text"
                        className="form-field"
                        name="code"
                        onChange={(e) => addSubjectValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Tên môn</label>
                      <input
                        type="text"
                        className="form-field"
                        name="title"
                        onChange={(e) => addSubjectValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Mô tả</label>
                      <input
                        type="text"
                        className="form-field"
                        name="description"
                        onChange={(e) => addSubjectValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Số tiết</label>
                      <input
                        type="number"
                        name="credit"
                        className="form-field"
                        min={1}
                        onChange={(e) => addSubjectValueChange(e)}
                      />
                    </div>
                  </>
                )}
                {action === ACTION.UPDATESUBJECT && (
                  <>
                    <div className="form-group">
                      <label htmlFor="">Mã môn</label>
                      <input
                        defaultValue={currentSubject.code}
                        type="text"
                        className="form-field"
                        name="code"
                        onChange={(e) => updateSubjectValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Tên môn</label>
                      <input
                        defaultValue={currentSubject.title}
                        type="text"
                        className="form-field"
                        name="title"
                        onChange={(e) => updateSubjectValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Mô tả</label>
                      <input
                        type="text"
                        className="form-field"
                        name="description"
                        defaultValue={currentSubject.description}
                        onChange={(e) => updateSubjectValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Số tiết</label>
                      <input
                        type="number"
                        name="credit"
                        className="form-field"
                        min={1}
                        defaultValue={currentSubject.credit}
                        onChange={(e) => updateSubjectValueChange(e)}
                      />
                    </div>
                  </>
                )}
                {action === ACTION.DELETESUBJECT && (
                  <h3>
                    Bạn có chắc muốn xóa môn học này không, các thông tin liên
                    quan môn học này sẽ mất?
                  </h3>
                )}
                {action === ACTION.ADDCLASS && (
                  <>
                    <div className="form-group">
                      <label htmlFor="">Học kì</label>
                      <select
                        name="semesterId"
                        className="form-field"
                        onChange={(e) =>
                          setAddClass({
                            ...addClass,
                            semesterId: e.target.value,
                          })
                        }
                        defaultValue={domain.semesters[0]?.id}
                      >
                        {domain.semesters.map((semester, idx) => (
                          <option selected={idx === 0} key={idx} value={semester.id}>
                            {semester.semesterName}
                          </option>
                        ))}
                      </select>
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Môn học</label>
                      <select
                        name="subjectId"
                        className="form-field"
                        onChange={(e) =>
                          setAddClass({
                            ...addClass,
                            subjectId: e.target.value,
                          })
                        }
                        defaultValue={domain.subjects[0]?.id}
                      >
                        {domain.subjects.map((subject, idx) => (
                          <option key={idx} value={subject.id}>
                            {subject.code} - {subject.title}
                          </option>
                        ))}
                      </select>
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Mã lớp</label>
                      <input
                        type="text"
                        className="form-field"
                        onChange={(e) =>
                          setAddClass({ ...addClass, code: e.target.value })
                        }
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Giảng viên</label>
                      <select
                        name="teacherId"
                        className="form-field"
                        onChange={(e) =>
                          setAddClass({
                            ...addClass,
                            teacherId: e.target.value,
                          })
                        }
                        defaultValue={domain.teachers[0]?.id}
                      >
                        {domain.teachers.map((teacher, idx) => (
                          <option key={idx} value={teacher.id}>
                            {teacher.teacherID} - {teacher.fullName}
                          </option>
                        ))}
                      </select>
                    </div>
                    <div className="form-group">
                      <label>Học viên</label>
                      <CheckListComponent
                        displayName={"fullName"}
                        item={domain.students}
                        own={addClass.students}
                        click={(i) => toggleStudent(i)}
                      ></CheckListComponent>
                    </div>
                    <div className="form-group">
                      <label>Ngày bắt đầu</label>
                      <input
                        className="form-field"
                        name="startDate"
                        type={"date"}
                        onChange={(e) =>
                          setAddClass({
                            ...addClass,
                            startDate: e.target.value,
                          })
                        }
                      ></input>
                    </div>
                    <div className="form-group">
                      <label>Ngày kết thúc</label>
                      <input
                        className="form-field"
                        name="endDate"
                        type={"date"}
                        onChange={(e) =>
                          setAddClass({
                            ...addClass,
                            endDate: e.target.value,
                          })
                        }
                      ></input>
                    </div>
                  </>
                )}
                                {action === ACTION.UPDATECLASS && (
                  <>
                    <div className="form-group">
                      <label htmlFor="">Học kì</label>
                      <select
                        name="semesterId"
                        className="form-field"
                        onChange={(e) =>
                          setCurrentClass({
                            ...currentClass,
                            semesterId: e.target.value,
                          })
                        }
                        defaultValue={currentClass.semesterId}
                      >
                        {domain.semesters.map((semester, idx) => (
                          <option key={idx} value={semester.id}>
                            {semester.semesterName}
                          </option>
                        ))}
                      </select>
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Môn học</label>
                      <select
                        name="subjectId"
                        className="form-field"
                        onChange={(e) =>
                          setCurrentClass({
                            ...currentClass,
                            subjectId: e.target.value,
                          })
                        }
                        defaultValue={currentClass.subjectId}
                      >
                        {domain.subjects.map((subject, idx) => (
                          <option key={idx} value={subject.id}>
                            {subject.code} - {subject.title}
                          </option>
                        ))}
                      </select>
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Mã lớp</label>
                      <input
                        type="text"
                        className="form-field"
                        onChange={(e) =>
                          setCurrentClass({ ...currentClass, code: e.target.value })
                        }
                        defaultValue={currentClass.code}
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="">Giảng viên</label>
                      <select
                        name="teacherId"
                        className="form-field"
                        onChange={(e) =>
                          setCurrentClass({
                            ...currentClass,
                            teacherId: e.target.value,
                          })
                        }
                        defaultValue={currentClass.teacherId}
                      >
                        {domain.teachers.map((teacher, idx) => (
                          <option key={idx} value={teacher.id}>
                            {teacher.teacherID} - {teacher.fullName}
                          </option>
                        ))}
                      </select>
                    </div>
                    <div className="form-group">
                      <label>Học viên</label>
                      <CheckListComponent
                        displayName={"fullName"}
                        item={domain.students}
                        own={currentClass.students}
                        click={(i) => toggleStudent2(i)}
                      ></CheckListComponent>
                    </div>
                    <div className="form-group">
                      <label>Ngày bắt đầu</label>
                      <input
                        className="form-field"
                        name="startDate"
                        type={"date"}
                        onChange={(e) =>
                          setCurrentClass({
                            ...currentClass,
                            startDate: e.target.value,
                          })
                        }
                        defaultValue={currentClass.startDate}
                      ></input>
                    </div>
                    <div className="form-group">
                      <label>Ngày kết thúc</label>
                      <input
                        className="form-field"
                        name="endDate"
                        type={"date"}
                        onChange={(e) =>
                          setCurrentClass({
                            ...currentClass,
                            endDate: e.target.value,
                          })
                        }
                        defaultValue={currentClass.endDate}
                      ></input>
                    </div>
                  </>
                )}
              {action === ACTION.DELETECLASS && <h3 className="text-danger">Bạn có chắc chắn xóa lớp học này, các dữ liệu liên quan sẽ mất và không thể hoàn tác?</h3>}
              </form>
            </ModalBody>
            <ModalFooter>
              <div className="align-center">
                <button onClick={submit} className="noselect primary">
                  <span className="text">Lưu</span>
                  <span className="icon">
                    <ion-icon
                      size="large"
                      name="checkmark-circle-outline"
                    ></ion-icon>
                  </span>
                </button>
              </div>
            </ModalFooter>
          </Modal>
        )}
      </ModalTransition>
    </div>
  );
};

export default SelfDomainManage;
export const createHead = (withWidth) => {
  return {
    cells: [
      {
        key: "name",
        content: "Name",
        isSortable: true,
        width: withWidth ? 25 : undefined,
      },
      {
        key: "party",
        content: "Party",
        shouldTruncate: true,
        isSortable: true,
        width: withWidth ? 15 : undefined,
      },
      {
        key: "term",
        content: "Term",
        shouldTruncate: true,
        isSortable: true,
        width: withWidth ? 10 : undefined,
      },
      {
        key: "content",
        content: "Comment",
        shouldTruncate: true,
      },
      {
        key: "more",
        shouldTruncate: true,
      },
    ],
  };
};

export const head = createHead(false);
