import { useCallback, useEffect, useRef, useState } from "react";
import { Link } from "react-router-dom";
import "./learn-detail.css";
import TreeComponent from "../../../components/tree/tree.component";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { useElementSize } from "usehooks-ts";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import AssignmentComponent from "../../../components/assignment/assignment.component";
import GridFilesComponent from "../../../components/grid-files/grid-files.component";
import CalendarComponent from "../../../components/calendar/calendar.component";
import { useParams } from "react-router-dom";
import { ROLE } from "../../../consts/role.const";
import $ from "jquery";
import { SCRIPT } from "../../../consts/script.const";
import "react-responsive-modal/styles.css";
import axiosClient from "../../../global/axios/axiosClient";
import { useSelector } from "react-redux";
import { ACTION } from "../../../consts/action.const";
import ContextScriptComponent from "../../../components/context-script/context-script.component";
import { set, useForm } from "react-hook-form";
import FileViewer from "react-file-viewer";
import Tabs, { Tab } from "react-best-tabs";
import "react-best-tabs/dist/index.css";
import SunEditor from "suneditor-react";
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";
import toast from "react-hot-toast";
import DataTableComponent from "../../../components/datatable/datatable.component";
import ExamScriptComponent from "../../../components/exam-script/exam-script.component";
import VideoScriptComponent from "../../../components/video-script/video-script.component";
import CheckListComponent from "../../../components/checklist/checklist.component";
const rootTemplate = (rootNode, select) => {
  return (
    <div className="root" key={rootNode?.id}>
      <button className="custom_btn" onClick={select}>
        {rootNode?.name}
      </button>
    </div>
  );
};
const LearnDetailPage = () => {
  const docs = [
    // {
    //   uri:
    //     "http://localhost:9000/uploads/ULRYB3ATJ56B/Screenshot%202021-04-28%20at%2014.04.23.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=minio%2F20210507%2F%2Fs3%2Faws4_request&X-Amz-Date=20210507T142426Z&X-Amz-Expires=432000&X-Amz-SignedHeaders=host&X-Amz-Signature=761187860be22801088ab8c212733f7f52af8f62d638f1341ee2ae4c18944251"
    //   // "http://localhost:9000/uploads/6QK5HJ84MAEM/RAS-118_CompanyCodes__SalesOffices.xlsx?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=minio%2F20210507%2F%2Fs3%2Faws4_request&X-Amz-Date=20210507T110429Z&X-Amz-Expires=432000&X-Amz-SignedHeaders=host&X-Amz-Signature=c20f9b77ffdc1a15910cea5acd3420b6583a1d4d38ce5716da30f1d0ea4315d5"
    //   // "https://res.cloudinary.com/cloudinaryforme/image/upload/v1618339571/workplace-1245776_1920_i9ayae.jpg"
    // },

    // {
    //   uri:
    //     "https://code.visualstudio.com/shortcuts/keyboard-shortcuts-macos.pdf"
    // },
    { uri: require("../../../docs/L490.pdf") },
  ];
  const [numPages, setNumPages] = useState(null);
  const [pageNumber, setPageNumber] = useState(1);

  function onDocumentLoadSuccess({ numPages }) {
    setNumPages(numPages);
  }
  const [test, setTest] = useState({
    title: "Danh sách chương",
    id: "root",
    children: [],
  }); // Create new plugin instance
  const [filterNodes, setFilterNodes] = useState(test);
  const { account, isRefresh, data } = useSelector((x) => x.auth);
  const [isShowAll, setIsShowAll] = useState(false);
  const { location } = useHistory();
  const { id, classId, subjectId } = useParams();
  const [squareRef, { width, height }] = useElementSize();
  const [showNavigationMenu, setShowNavigationMenu] = useState(false);
  const [scriptType, setScriptType] = useState("");
  const [isOpen, setIsOpen] = useState(false);
  const [action, setAction] = useState("");
  const [currentFile, setCurrentFile] = useState(null);
  const [assignment, setAssignment] = useState(null);
  const [projects, setProjects] = useState([]);
  const toggleModal = async (action, item) => {
    setAction(action);
    setIsOpen(!isOpen);
    setCurrentFile(item);
    if (action === ACTION.MANAGEPROJECT) {
      const result = await axiosClient.get(
        `/api/CRM/project/own/${account.id}?subjectId=${id}`
      );
      setProjects(result);
    }
  };
  const memoizedCallback = useCallback(() => {
    if (width <= 600) {
      setShowNavigationMenu(true);
    } else {
      setShowNavigationMenu(false);
    }
  }, [width]);
  const [refresh, setRefresh] = useState(false);
  const [availableSection, setAvailableSection] = useState([]);
  const [currentNode, setCurrentNode] = useState(null);
  const [selectedSection, setSelectedSection] = useState(null);
  const [assignmentResultRef, setAssignmentResultRef] = useState([]);
  const [submittedResult, setSubmittedResult] = useState([]);
  const [event, setEvent] = useState([]);
  const [students, setStudents] = useState([
    {
      fullName: "Trần Liễu Nhựt Anh",
      studentID: "18110101",
      permanentAddress: "TP.HCM",
      identityNo: "999999999999",
      phoneNumber: "12313131231",
      currentAddress: "TP.HCM",
      birthDate: "2000-12-27",
      joinDate: "5/15/2022 11:43:59 AM",
      domainId: "b70d4057-ee17-4ff8-9e18-08da3503ccc0",
      id: "21c378ad-69f8-4a78-a1bc-08da362d8756",
      accountId: "b36c2a83-aabd-40c3-6b72-08da3503ce41",
    },
  ]);
  useEffect(() => {
    const fetchData = async () => {
      var result = await axiosClient.get(
        `/api/Course/learn/${id}/${subjectId}`
      );
      if (result) {
        setTest({
          ...test,
          children: result.sections,
        });
        setFilterNodes({
          ...test,
          children: result.sections,
        });
        const available = [];
        result.sections.forEach((section, idx) => {
          if (section.children.length > 0) {
            section.children.forEach((child, i) => {
              available.push(child);
            });
          } else {
            available.push(section);
          }
        });
        setAvailableSection([...available]);
        setSelectedSection(available[0].id);
        if (currentNode !== null) {
          console.log(available);
          console.log(currentNode);
          console.log(available.filter((x) => x.id === currentNode.id)[0]);
          setCurrentNode(available.filter((x) => x.id === currentNode.id)[0]);
        } else {
          setCurrentNode(available[0]);
        }
        console.log(id);
        if (account && account.role === ROLE.STUDENT) {
          const assignmentResult = await axiosClient.get(
            `/api/course/${id}/assignment/result?studentId=${data.student.id}`
          );

          setAssignmentResultRef(assignmentResult.assignmentResult);

          const eventResult = await axiosClient.get(
            `/api/course/subject/${id}/event`
          );
          setEvent(eventResult.data);
        }

        const classStudent = await axiosClient.get(`/api/course/${id}/student`);
        setStudents(classStudent.students);
        if (account && account.role === ROLE.TEACHER) {
          const submitted = await axiosClient.get(
            `/api/Course/sections/${available[0].id}/assignment`
          );
          console.log(submitted);
          setSubmittedResult(submitted.result);
        }
      }
    };
    fetchData();
  }, [refresh, setRefresh, isRefresh]);
  const MySwal = withReactContent(Swal);

  const selectNode = (node) => {
    setCurrentNode(node);
  };
  useEffect(() => {
    memoizedCallback();
  }, [width]);
  const [searchNode, setSearchNode] = useState("");
  const [availableExam, setAvailableExam] = useState([]);
  useEffect(() => {
    const fetchData = async () => {
      const result = await axiosClient.get(
        `/api/course/exams?teacherId=${account?.id || "E234B73C-D762-403E-6B73-08DA3503CE41"
        }`
      );
      setAvailableExam(result.exams);
    };
    fetchData();
  }, [isRefresh]);
  useEffect(() => {
    if (searchNode !== "") {
      var result = test.children.filter((x) =>
        x.name.toLowerCase().includes(searchNode.toLowerCase())
      );
      console.log(result);
      test.children = [...result];
      setFilterNodes(test);
    } else {
      setFilterNodes(test);
    }
  }, [searchNode]);
  const openNavigation = () => {
    MySwal.fire({
      title: "Navigation",
      html: (
        <div className="learning-navigation">
          <TreeComponent
            rootTemplate={rootTemplate}
            rootNode={filterNodes}
            isShowAll={isShowAll}
            selectNode={selectNode}
            id={id}
            refresh={() => setRefresh(!refresh)}
          ></TreeComponent>
        </div>
      ),
      icon: "info",
      showConfirmButton: false,
    });
  };

  const selectDay = (day) => { };
  const selectFile = {};
  const file = "../../docs/Poster-Gian.pdf";
  const type = "pdf";
  const [script, setScript] = useState({
    heading: "",
    body: "",
    footer: "",
  });

  const valueChange = (e, isFile = false) => {
    if (!isFile) {
      setScript({
        ...script,
        [e.target.name]: e.target.value,
      });
    } else {
      setScript({
        ...script,
        [e.target.name]: e.target.files[0],
      });
    }
  };
  const [heading, setHeading] = useState("");
  const [body, setBody] = useState("");
  const [footer, setFooter] = useState("");
  const submit = async () => {
    let isRefresh = false;
    switch (action) {
      case ACTION.MODIFYCLASS:
        const temp = {
          ...script,
          scriptType: scriptType,
          sectionId: selectedSection,
          action: 1,
          heading: heading,
          body: body,
          footer: footer,
          videoScriptTitle: script.title,
          videoScriptDescription: script.description
        };
        console.log(temp);

        const postData = new FormData();
        Object.keys(temp).forEach((key) => {
          postData.append(key, temp[key]);
        });
        const result = await axiosClient.post(
          "/api/course/sections/scripts",
          postData
        );
        console.log(result);
        if (result.status === 200) {
          isRefresh = true;
        }
        break;
      case ACTION.DELETESCRIPT:
        //console.log(removeScript);
        const deleteResult = await axiosClient.delete(
          `/api/course/sections/scripts/${removeScript.id}`
        );
        console.log(deleteResult);
        if (deleteResult.status === 200) {
          isRefresh = true;
        }
        break;
      case ACTION.SUBMITFILE:
        console.log(assignment);
        const uploadData = new FormData();
        uploadData.append("file", assignment.file);
        const submitResult = await axiosClient.post(
          `/api/course/sections/scripts/${assignment.id}/submit?studentId=${data.student.id}`,
          uploadData
        );
        console.log(submitResult);
        if (submitResult.status === 200) {
          isRefresh = true;
        }
        break;
      case ACTION.EDITFILE:
        console.log(currentFile);

        console.log(currentFile);
        const editDocument = new FormData();
        editDocument.append("action", 2);
        Object.keys(currentFile).map((key, idx) =>
          editDocument.append(key, currentFile[key])
        );
        const editFile = await axiosClient.post(
          "/api/course/sections/scripts",
          editDocument
        );
        console.log(editFile);
        if (editFile.status === 200) {
          isRefresh = true;
        }
        break;
      default:
        break;
    }
    if (isRefresh) {
      toast.success("Thành công", { duration: 1000 });
      setRefresh(!refresh);
      toggleModal("");
      formRef.current.reset();
    }
    else {
      toast.error("Không thành công", { duration: 1000 });
    }
  };
  const [isEditMode, setIsEditMode] = useState(false);
  const [removeScript, setRemoveScript] = useState({});
  const remove = (item) => {
    setRemoveScript(item);
    toggleModal(ACTION.DELETESCRIPT);
  };
  const formRef = useRef();
  let scriptFiles = [];
  function downloadFile(absoluteUrl) {
    var link = document.createElement("a");
    link.href = absoluteUrl;
    link.download = "true";
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }
  const selectAssignmentFile = (e) => {
    setAssignment({
      ...assignment,
      file: e.target.files[0],
    });
  };
  const removeAssignment = async (temp) => {
    const result = await axiosClient.delete(
      `/api/course/sections/scripts/${assignment.id}/delete?submitId=${temp.id}&fileId=${temp.fileId}`
    );
    if (result.status === 200) {
      setRefresh(!refresh);
      toggleModal("");
      toast.success("Thành công", { duration: 1000 });
      formRef.current.reset();
    }
  };
  const saveContext = async (data) => {
    const temp = {
      ...data,
      action: 2,
    };
    console.log(temp);

    const postData = new FormData();
    Object.keys(temp).forEach((key) => {
      postData.append(key, temp[key]);
    });
    const result = await axiosClient.post(
      "/api/course/sections/scripts",
      postData
    );
    console.log(result);
    if (result.status === 200) {
      setRefresh(!refresh);
      toast.success("Thành công", { duration: 1000 });
    }
  };
  const images = "png, jpeg, gif, bmp";
  const [miniAction, setMiniAction] = useState("");
  const [addProject, setAddProject] = useState({
    students: []
  });
  const [currentProject, setCurrentProject] = useState(null);
  const addProjectValueChange = (e) => {
    setAddProject({
      ...addProject,
      [e.target.name]: e.target.value
    })
  }
  const [addTask, setAddTask] = useState({});
  const addTaskValueChange = (e) => {
    setAddTask({
      ...addTask,
      [e.target.name]: e.target.value
    });
  }
  const submitAddTask = async () => {
    const data1 = {
      "taskName": "string",
      "description": "string",
      "assigneeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "assigneeFullname": "string",
      "projectId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "status": 0,
      "startAt": "2022-06-26T05:50:25.166Z",
      "dueTo": "2022-06-26T05:50:25.166Z"
    };
    const data = {
      ...addTask,
      projectId: currentProject.id,
      status: 0
    }
    const result = await axiosClient.post("/api/crm/task", data);
    if (result.status === 200) {
      toast.success("Thêm công việc thành công");
      setRefresh(!refresh);
      formRef.current.reset();
    }

  }
  const [toggleAddTask, setToggleAddTask] = useState(false);
  const [activeTab, setActiveTab] = useState(1);
  const projectSubmit = async () => {
    switch (miniAction) {
      case ACTION.ADDPROJECT:
        const data = {
          ...addProject,
          leaderFullname: students.find(x => x.accountId === addProject.leaderId).fullName,
          ownerId: account.id,
          members: [...addProject.students.map((student) => {
            const newStudent = {
              memberFullname: student.fullName,
              accountId: student.accountId,
              studentID: student.studentID
            }
            return newStudent;
          })],
          subjectId: id
        }
        console.log(data);
        var result = await axiosClient.post("/api/crm/project", data);
        console.log(result);
        if (result.status === 200) {
          setMiniAction('');
          setAddProject({
            students: []
          });
          setRefresh(!refresh);
        }
        break;
      case ACTION.EDITPROJECT:
        // if (currentProject) {
        //   const deleteResult = await axiosClient.delete(`/api/crm/project/${currentProject.id}`);
        //   if (deleteResult.status === 200) {
        //     setMiniAction('');
        //     setCurrentProject(null);
        //     setRefresh(!refresh);
        //   }
        // }
        break;
      case ACTION.DELETEPROJECT:
        console.log(currentProject);
        if (currentProject) {
          const deleteResult = await axiosClient.delete(`/api/crm/project/${currentProject.id}`);
          if (deleteResult.status === 200) {
            setMiniAction('');
            setCurrentProject(null);
            setRefresh(!refresh);
          }
        }
        break;
      default:
        break;
    }
  }
  const toggleMember = (e) => {
    if (addProject.students.find(x => x === e)) {
      setAddProject({
        ...addProject,
        students: [...addProject.students.filter(x => x !== e)]
      })
    }
    else {
      setAddProject({
        ...addProject,
        students: [...addProject.students, e]
      })
    }

  }
  const [toggleEditTask, setToggleEditTask] = useState(false);
  return (
    <div className="learning-detail" ref={squareRef}>
      {showNavigationMenu && (
        <div className="hidden-navigation" onClick={openNavigation}>
          <ion-icon name="compass-outline"></ion-icon>
        </div>
      )}
      <div className="learning-navigation">
        <div>
          {(account?.role === ROLE.TEACHER || account === undefined) && (
            <div className="d-flex align-center">
              <button
                onClick={() => setIsEditMode(!isEditMode)}
                className="noselect primary text-center"
              >
                <span className="text">
                  {!isEditMode ? "Cấu hình" : "Thoát"}
                </span>
                <span className="icon">
                  <ion-icon
                    size="large"
                    name={`${!isEditMode ? "settings" : "close"}-outline`}
                  ></ion-icon>
                </span>
              </button>
              <br></br>
              <button
                className="noselect primary text-center"
                onClick={() => toggleModal(ACTION.MANAGEPROJECT)}
              >
                <span className="text">Project</span>
                <span className="icon">
                  <ion-icon size="large" name="duplicate-outline"></ion-icon>
                </span>
              </button>
            </div>
          )}
          {account && account.role === ROLE.STUDENT && (
            <div className="align-center">
              <Link to={`/dashboard/chat?id=${account.id}`}>
                <ion-icon
                  onClick={() => console.log("chat")}
                  size="large"
                  name="chatbox-ellipses-outline"
                ></ion-icon>
              </Link>
            </div>
          )}
        </div>
        <br></br>
        <CalendarComponent
          isSelectRangeEnable={false}
          events={event.map((x) => {
            const data = {
              ...x,
              day: Number.parseInt(x.dueTo.substring(8, 10)),
              month: Number.parseInt(x.dueTo.substring(5, 7)),
              year: Number.parseInt(x.dueTo.substring(0, 4)),
              absoluteDate: Date.parse(x.dueTo),
              due: x.dueTo
            };
            return data;
          })}
        ></CalendarComponent>
        <Link to="#" onClick={() => setIsShowAll(!isShowAll)}>
          Tất cả
        </Link>
        <TreeComponent
          rootTemplate={rootTemplate}
          rootNode={filterNodes}
          isShowAll={isShowAll}
          selectNode={selectNode}
          isModifiable={isEditMode}
          id={id}
          refresh={() => setRefresh(!refresh)}
          currentNode={currentNode}
        ></TreeComponent>
      </div>
      <div className="learning-area">
        {isEditMode && (
          <div className="align-center">
            <button
              onClick={() => toggleModal(ACTION.MODIFYCLASS)}
              className="noselect primary text-center"
            >
              <span className="text">Quản lý</span>
              <span className="icon">
                <ion-icon size="large" name="add-circle-outline"></ion-icon>
              </span>
            </button>
          </div>
        )}
        <GridFilesComponent
          files={scriptFiles}
          isModifiable={isEditMode}
          removeSubmit={remove}
          toggle={toggleModal}
        ></GridFilesComponent>
        {currentNode?.scripts.map((script, idx) => {
          switch (script.scriptType) {
            case SCRIPT.CONTEXT:
              return (
                <ContextScriptComponent
                  key={idx}
                  isModifiable={isEditMode}
                  remove={remove}
                  script={script}
                  save={saveContext}
                ></ContextScriptComponent>
              );
            case SCRIPT.DOCUMENT:
              scriptFiles.push(script);
              break;
            case SCRIPT.ASSIGNMENT:
              return (
                <AssignmentComponent
                  key={idx}
                  assignment={script}
                  isModifiable={isEditMode}
                  toggle={() => {
                    toggleModal(ACTION.SUBMITFILE);
                    setAssignment(script);
                  }}
                  remove={remove}
                  assignmentRef={assignmentResultRef}
                  removeAssignment={removeAssignment}
                  students={students}
                  submittedResult={submittedResult}
                  save={saveContext}
                ></AssignmentComponent>
              );
            case SCRIPT.EXAM:
              return (
                <ExamScriptComponent
                  key={idx}
                  exam={script}
                  remove={remove}
                  isModifiable={isEditMode}
                ></ExamScriptComponent>
              );
            case SCRIPT.VIDEO:
              return (
                <VideoScriptComponent key={idx}
                  script={script}
                  remove={remove}
                  save={saveContext}
                  isModifiable={isEditMode}></VideoScriptComponent>
              )
            default:
              return <></>;
          }
        })}

        {/* {selectedSection.scripts.map((script, idx) => (
          <div>{script.scriptType}</div>
        ))} */}
      </div>
      <ModalTransition>
        {isOpen && (
          <Modal
            width={"x-large"}
            css={{ width: "100%", height: "100%" }}
            onClose={toggleModal}
          >
            <ModalHeader appearance="info">
              <ModalTitle>
                {action === ACTION.ADDSCRIPT && (
                  <h3 className="text-center">Thêm nội dung</h3>
                )}
                {action === ACTION.DELETESCRIPT && (
                  <h3 className="text-center">Xóa nội dung</h3>
                )}
                {action === ACTION.MANAGEPROJECT && <h2>Quản lý project</h2>}
              </ModalTitle>
            </ModalHeader>
            <ModalBody>
              <form className="form" ref={formRef}>
                {action === ACTION.SUBMITFILE && (
                  <>
                    <div className="form-group">
                      <div className="align-center">
                        <h3>Nộp bài tập</h3>
                        <h5>{assignment.assignmentScriptTitle}</h5>
                        <p>{assignment.detail}</p>
                      </div>
                      <div>
                        Mở từ:
                        {!isEditMode ? (
                          <span> {assignment.assignmentScriptOpenAt}</span>
                        ) : (
                          <input
                            className="form-field"
                            defaultValue={assignment.assignmentScriptOpenAt}
                          />
                        )}
                      </div>
                      <div>
                        Đến ngày:
                        {!isEditMode ? (
                          <span> {assignment.assignmentScriptDueTo}</span>
                        ) : (
                          <input
                            className="form-field"
                            defaultValue={assignment.assignmentScriptDueTo}
                          />
                        )}
                      </div>
                      <label>Nộp bài</label>
                      <div className="form-group">
                        <input
                          className="form-field"
                          type="file"
                          disabled={
                            new Date(
                              assignment.assignmentScriptDueTo
                            ).getTime() < new Date().getTime() ||
                            assignmentResultRef.find(
                              (x) => x.assignmentId === assignment.id
                            ) || new Date(
                              assignment.assignmentScriptStartAt
                            ).getTime() > new Date().getTime()
                          }
                          onChange={(e) => selectAssignmentFile(e)}
                        ></input>
                      </div>
                      {new Date(assignment.assignmentScriptDueTo).getTime() >
                        new Date().getTime() &&
                        assignmentResultRef.find(
                          (x) => x.assignmentId === assignment.id && x.studentId === data.student.id
                        ) && (
                          <div className="remove">
                            <h5>
                              {
                                assignmentResultRef.find(
                                  (x) => x.assignmentId === assignment.id
                                ).fileName
                              }
                            </h5>
                            <ion-icon
                              size="large"
                              onClick={() =>
                                removeAssignment(
                                  assignmentResultRef.find(
                                    (x) => x.assignmentId === assignment.id
                                  )
                                )
                              }
                              name="trash-outline"
                            ></ion-icon>
                          </div>
                        )}
                    </div>
                  </>
                )}
                {action === ACTION.OPENFILE && (
                  <>
                    {!images.includes(currentFile.fileType) ? (
                      <FileViewer
                        css={{ width: "100%" }}
                        fileType={currentFile.fileType}
                        filePath={currentFile.documentUrl}
                      ></FileViewer>
                    ) : (
                      <img
                        alt="dkm"
                        style={{
                          width: "100%",
                          height: "100%",
                          objectFit: "cover",
                        }}
                        src={currentFile.documentUrl}
                      />
                    )}
                  </>
                )}
                {action === ACTION.EDITFILE && (
                  <>
                    <label>Tiêu đề</label>
                    <input type="text" defaultValue={currentFile.documentTitle} className="form-field" onChange={(e) => setCurrentFile({ ...currentFile, title: e.target.value })} />
                    <label>Chọn file</label>
                    <input
                      className="form-field"
                      accept=".xlsx, image/*, .docx,.csv,.pdf"
                      type="file"
                      onChange={(e) =>
                        setCurrentFile({
                          ...currentFile,
                          file: e.target.files[0],
                        })
                      }
                    ></input>
                  </>
                )}
                {action === ACTION.MODIFYCLASS && (
                  <div>
                    <Tabs
                      activeTab="1"
                      className="mt-5"
                      ulClassName=""
                      activityClassName="bg-success"
                    >
                      <Tab title="Chương học">
                        <div>
                          <h3>Bước 1: Chọn chương</h3>
                          {availableSection.length > 0 && (
                            <select
                              onChange={(e) =>
                                setSelectedSection(e.target.value)
                              }
                              name="section"
                              className="form-field"
                              defaultValue={availableSection[0].id}
                            >
                              {availableSection.map((section, idx) => (
                                <option value={section.id} key={idx}>
                                  {section.title}
                                </option>
                              ))}
                            </select>
                          )}
                          <h3>Bước 2: Thêm nội dung</h3>
                          <select
                            onChange={(e) => setScriptType(e.target.value)}
                            className="form-field"
                            defaultValue={scriptType}
                            name="scriptType"
                            required={true}
                          >
                            <option value={""}>Chọn loại</option>
                            <option value={SCRIPT.DOCUMENT}>Tài liệu</option>
                            <option value={SCRIPT.EXAM}>Bài kiểm tra</option>
                            <option value={SCRIPT.QUIZ}>Quiz</option>
                            <option value={SCRIPT.ASSIGNMENT}>Nộp bài</option>
                            <option value={SCRIPT.CONTEXT}>Kiến thức</option>
                            <option value={SCRIPT.VIDEO}>Bài giảng</option>
                          </select>
                          <input
                            className="form-field"
                            name="title"
                            placeholder="Tiêu đề"
                            onChange={(e) => valueChange(e)}
                          />
                          <input
                            className="form-field"
                            placeholder="Mô tả"
                            name="description"
                            onChange={(e) => valueChange(e)}
                          />
                          {scriptType === SCRIPT.VIDEO && <div>
                            <div className="form-group">
                              <label>Chọn bài giảng</label>
                              <input
                                name="file"
                                accept="video/mp4,video/x-m4v,video/*"
                                type={'file'} className="form-field" onChange={(e) => valueChange(e, true)}></input>
                            </div>

                          </div>}
                          {scriptType === SCRIPT.DOCUMENT && (
                            <div>
                              <input
                                placeholder="chọn file"
                                className="form-field"
                                type="file"
                                name="file"
                                id="document"
                                accept=".xlsx, image/*, .docx,.csv,.pdf"
                                onChange={(e) => valueChange(e, true)}
                              />
                            </div>
                          )}
                          {scriptType === SCRIPT.ASSIGNMENT && (
                            <div>
                              <label>Hướng dẫn</label>
                              <textarea
                                type="date"
                                name="assignmentScriptDescription"
                                id="tutorial"
                                className="form-field"
                                onChange={(e) => valueChange(e)}
                              ></textarea>
                              <label>Thời gian mở</label>
                              <input
                                type="date"
                                name="assignmentScriptOpenAt"
                                id="start"
                                className="form-field"
                                onChange={(e) => valueChange(e)}
                              />
                              <label>Thời gian đóng</label>
                              <input
                                type="date"
                                name="assignmentScriptDueTo"
                                id="end"
                                className="form-field"
                                onChange={(e) => valueChange(e)}
                              />
                            </div>
                          )}
                          {scriptType === SCRIPT.EXAM && (
                            <>
                              <div className="form-group">
                                <label>Chọn bài kiểm tra</label>
                                <select
                                  className="form-field"
                                  name="examId"
                                  onChange={(e) => valueChange(e)}
                                >
                                  <option value={""}>Chọn bài kiểm tra</option>
                                  {availableExam.map((exam, idx) => (
                                    <option key={idx} value={exam.id}>
                                      {exam.title}
                                    </option>
                                  ))}
                                </select>
                              </div>
                              <div className="form-group">
                                <label htmlFor="">Thời gian làm bài</label>
                                <input
                                  type="number"
                                  className="form-field"
                                  name="duration"
                                  min={10}
                                  defaultValue={10}
                                  onChange={(e) => valueChange(e)}
                                />
                              </div>
                              <div className="form-group">
                                <label htmlFor="">Số lần làm lại</label>
                                <input
                                  type="number"
                                  className="form-field"
                                  name="totalAttempt"
                                  min={1}
                                  defaultValue={1}
                                  onChange={(e) => valueChange(e)}
                                />
                              </div>
                              <div className="form-group">
                                <label htmlFor="">Trộn câu hỏi</label>
                                <input
                                  className=""
                                  type="checkbox"
                                  name="isShuffle"
                                  onChange={(e) => {
                                    if (e.checked) {
                                      setScript({ ...script, isShuffle: true });
                                    } else {
                                      setScript({
                                        ...script,
                                        isShuffle: false,
                                      });
                                    }
                                  }}
                                />
                              </div>
                            </>
                          )}
                          {scriptType === SCRIPT.QUIZ && <div></div>}
                          {scriptType === SCRIPT.CONTEXT && (
                            <>
                              <div className="form-group">
                                <label htmlFor="">Tiêu đề</label>
                                <SunEditor
                                  name="heading"
                                  height="100%"
                                  onInput={(e) => {
                                    setHeading(e.target.firstChild.outerHTML);
                                  }}
                                />
                              </div>
                              <div className="form-group">
                                <label htmlFor="">Nội dung</label>
                                <SunEditor
                                  name="body"
                                  height="100%"
                                  onInput={(e) =>
                                    setBody(e.target.firstChild.outerHTML)
                                  }
                                />
                              </div>
                              <div className="form-group">
                                <label htmlFor="">Kết thúc</label>
                                <SunEditor
                                  name="footer"
                                  height="100%"
                                  onInput={(e) =>
                                    setFooter(e.target.firstChild.outerHTML)
                                  }
                                />
                              </div>
                            </>
                          )}
                        </div>
                      </Tab>
                      <Tab title="Thành viên">
                        <div className="datatable">
                          <table className="table-glassmorphism">
                            <thead>
                              <tr>
                                <th>STT</th>
                                <th>Mã HS/SV</th>
                                <th>Họ và tên</th>
                                <th>SĐT</th>
                                <th>Ngày sinh</th>
                                <th>CMND/CCCD</th>
                                <th></th>
                              </tr>
                            </thead>
                            <tbody>
                              {students.map((student, idx) => (
                                <tr key={idx}>
                                  <td>{idx + 1}</td>
                                  <td>{student.studentID}</td>
                                  <td>{student.fullName}</td>
                                  <td>{student.phoneNumber}</td>
                                  <td>{student.birthDate}</td>
                                  <td>{student.identityNo}</td>
                                  <td>
                                    <div className="align-center">
                                      <Link
                                        to={`/dashboard/chat?id=${student.accountId}`}
                                      >
                                        <ion-icon
                                          onClick={() => console.log("chat")}
                                          size="large"
                                          name="chatbox-ellipses-outline"
                                        ></ion-icon>
                                      </Link>
                                    </div>
                                  </td>
                                </tr>
                              ))}
                            </tbody>
                          </table>
                        </div>
                      </Tab>
                      <Tab title="Điểm">Quản lý điểm</Tab>
                    </Tabs>
                  </div>
                )}
                {action === ACTION.DELETESCRIPT && (
                  <h3 className="text-center text-danger">
                    Bạn có chắc chắn xóa nội dung học này? Không thể hoàn tác
                  </h3>
                )}
                {action === ACTION.MANAGEPROJECT && (
                  <>
                    {miniAction === '' && <>
                      <button
                        type="button"
                        className="mt-1 noselect primary text-center"
                        onClick={() => setMiniAction(ACTION.ADDPROJECT)}
                      >
                        <span className="text">Thêm</span>
                        <span className="icon">
                          <ion-icon
                            size="large"
                            name="add-outline"
                          ></ion-icon>
                        </span>
                      </button>
                      <div className="datatable">
                        <table className="table">
                          <thead>
                            <tr>
                              <th>Tên project</th>
                              <th>Mô tả</th>
                              <th>SL thành viên</th>
                              <th>Ngày bắt đầu</th>
                              <th>Ngày kết thúc</th>
                              <th>Trạng thái</th>
                              <th></th>
                            </tr>
                          </thead>
                          <tbody>
                            {projects.map((project, idx) => (
                              <tr key={idx}>
                                <td className="cursor-pointer" onClick={() => {
                                  setMiniAction(ACTION.PROJECTDETAIL)
                                  setCurrentProject(project);
                                }}>{project.name}</td>
                                <td>{project.description}</td>
                                <td>{project.members.length}</td>
                                <td>{project.start}</td>
                                <td>{project.end}</td>
                                <td>
                                  {project.isExpired ?
                                    'Hết hạn' : project.isDone
                                      ? "Hoàn thành"
                                      : "Chưa hoàn thành"}
                                </td>
                                <td className="align-center">
                                  <button
                                    type="button"
                                    className="noselect secondary mb-1 text-center"
                                    onClick={() => {
                                      setCurrentProject(project);
                                      setMiniAction(ACTION.EDITPROJECT);
                                    }
                                    }
                                  >
                                    <span className="text">Sửa</span>
                                    <span className="icon">
                                      <ion-icon
                                        size="large"
                                        name="pencil-outline"
                                      ></ion-icon>
                                    </span>
                                  </button>
                                  <button
                                    type="button"
                                    className="noselect danger text-center"
                                    onClick={() => {
                                      setMiniAction(ACTION.DELETEPROJECT);
                                      setCurrentProject(project)
                                    }

                                    }
                                  >
                                    <span className="text">Xóa</span>
                                    <span className="icon">
                                      <ion-icon
                                        size="large"
                                        name="trash-outline"
                                      ></ion-icon>
                                    </span>
                                  </button>
                                </td>
                              </tr>
                            ))}
                          </tbody>
                        </table>
                      </div>
                    </>
                    }
                    {miniAction === ACTION.ADDPROJECT && <>
                      <button
                        type="button"
                        className="mt-1 noselect primary text-center"
                        onClick={() => setMiniAction("")}
                      >
                        <span className="text">Trở lại</span>
                        <span className="icon">
                          <ion-icon size='large' name="arrow-back-outline"></ion-icon>
                        </span>
                      </button>
                      <div className="form-group">
                        <label htmlFor="">Tên project</label>
                        <input type="text" name="name" className="form-field" onChange={(e) => addProjectValueChange(e)} />
                      </div>
                      <div className="form-group">
                        <label htmlFor="">Mô tả</label>
                        <input type="text" name="description" className="form-field" onChange={(e) => addProjectValueChange(e)} />
                      </div>
                      <div className="form-group">
                        <label htmlFor="">Leader</label>
                        <select className="form-field" name="leaderId" onChange={(e) => addProjectValueChange(e)}>
                          <option value={''}>Chọn nhóm trưởng</option>
                          {students.map((student, idx) =>
                            <option value={student.accountId} key={idx}>
                              {student.studentID} - {student.fullName}
                            </option>)}
                        </select>
                      </div>
                      <div className="form-group">
                        <label htmlFor="">Ngày bắt đầu</label>
                        <input type="date" name="start" className="form-field" onChange={(e) => addProjectValueChange(e)} />
                      </div>
                      <div className="form-group">
                        <label htmlFor="">Ngày kết thúc</label>
                        <input type="date" name="end" className="form-field" onChange={(e) => addProjectValueChange(e)} />
                      </div>
                      <div className="form-group">
                        <CheckListComponent displayName={"fullName"}
                          item={students.filter(x => x.accountId !== addProject.leaderId)}
                          own={addProject.students}
                          click={(i) => toggleMember(i)}>

                        </CheckListComponent>
                      </div>
                      <div className="form-group d-flex justify-content-end">
                        <button
                          type="button"
                          className="noselect primary text-center"
                          onClick={projectSubmit}
                        >
                          <span className="text">Trở lại</span>
                          <span className="icon">
                            <ion-icon size='large' name="arrow-back-outline"></ion-icon>
                          </span>
                        </button>
                      </div>
                    </>}
                    {miniAction === ACTION.DELETEPROJECT && <>
                      <button
                        type="button"
                        className="mt-1 noselect primary text-center"
                        onClick={() => setMiniAction("")}
                      >
                        <span className="text">Trở lại</span>
                        <span className="icon">
                          <ion-icon size='large' name="arrow-back-outline"></ion-icon>
                        </span>
                      </button>
                      <h3 className="text-danger">Bạn có chắc chắn xoá project này không? Không thể hoàn tác</h3>

                      <div className="form-group d-flex justify-content-end">
                        <button
                          type="button"
                          className="noselect primary text-center"
                          onClick={projectSubmit}
                        >
                          <span className="text">Lưu</span>
                          <span className="icon">
                            <ion-icon size='large' name="arrow-back-outline"></ion-icon>
                          </span>
                        </button>
                      </div>
                    </>}
                    {miniAction === ACTION.PROJECTDETAIL && <>
                      <div className="d-flex">
                        <button
                          type="button"
                          className="mt-1 noselect primary text-center"
                          onClick={() => setMiniAction("")}
                        >
                          <span className="text">Trở lại</span>
                          <span className="icon">
                            <ion-icon size='large' name="arrow-back-outline"></ion-icon>
                          </span>
                        </button>  <Link
                          className="mt-1 ml-2 noselect btn btn-primary text-center"
                          to={`${location.pathname}/report`}
                        >
                          <span className="text">Report</span>
                          <span className="icon">
                            <ion-icon size='large' name="bar-chart-outline"></ion-icon>
                          </span>
                        </Link>
                      </div>
                      <div className="form-group">
                        <label>Tên project: {currentProject?.name}</label>
                      </div>
                      <div className="form-group">
                        <label>Mô tả: {currentProject?.description}</label>
                      </div>
                      <div className="form-group">
                        <label>Trưởng nhóm: {currentProject?.leaderFullname}</label>
                      </div>
                      <hr></hr>
                      <div className="form-group">
                        <label>Danh sách thành viên</label>
                        {currentProject?.members.length > 0 && <ul>
                          {currentProject.members.map((member, idx) =>
                            <li key={idx}>
                              {member.studentID} - {member.memberFullname}
                            </li>)}
                        </ul>}
                      </div>
                      <hr></hr>
                      <div className="form-group">
                        <button type="button" onClick={() => setToggleAddTask(!toggleAddTask)} className="btn btn-primary">Thêm công việc <ion-icon size='large' name="add-circle-outline"></ion-icon></button>
                        {toggleAddTask && <>
                          <div className="form-group">
                            <label>Tên công việc</label>
                            <input onChange={(e) => addTaskValueChange(e)} type="text" name="taskName" className="form-field" />
                          </div>
                          <div className="form-group">
                            <label>Mô tả</label>
                            <input onChange={(e) => addTaskValueChange(e)} type="text" name="description" className="form-field" />
                          </div>
                          <div className="form-group">
                            <label>Người thực hiện</label>
                            <select name="assigneeId" onChange={(e) => addTaskValueChange(e)} className="form-field">
                              <option value={''}>
                                Chọn người thực hiện
                              </option>
                              {currentProject.members.map((mem, idx) =>
                                <option key={idx} value={mem.accountId}>
                                  {mem.memberFullname}
                                </option>)}

                            </select>
                          </div>
                          <div className="form-group">
                            <label>Bắt đầu</label>
                            <input onChange={(e) => addTaskValueChange(e)} type="date" name="startAt" className="form-field" />
                          </div>
                          <div className="form-group">
                            <label>Kết thúc</label>
                            <input onChange={(e) => addTaskValueChange(e)} type="date" name="dueTo" className="form-field" />
                          </div>
                          <div className="form-group d-flex justify-content-center">
                            <button onClick={submitAddTask} className="btn btn-primary" type="button">Lưu</button>
                          </div>
                        </>}
                        <label htmlFor="">Danh sách công việc</label>
                        {currentProject?.tasks.length > 0 &&
                          <table className="table">
                            <tbody>
                              {currentProject.tasks.map((task, idx) =>
                                <tr key={idx}>
                                  <td>{task.taskName}</td>
                                  <td>{task.description}</td>
                                  <td>{students.find(x => x.accountId === task.assigneeId).fullName}</td>
                                  <td>{task.status}</td>
                                  <td className="d-flex">
                                    <button type="button" className="btn btn-warning">Sửa</button>
                                    <button type="button" className="btn btn-danger">Xoá</button>
                                  </td>
                                </tr>
                              )}
                            </tbody></table>}
                      </div>
                    </>}
                  </>
                )}
              </form>
            </ModalBody>
            <ModalFooter>
              {isEditMode && (
                <>
                  <button onClick={toggleModal} className="noselect secondary">
                    <span className="text">Hủy</span>
                    <span className="icon">
                      <ion-icon size="large" name="exit-outline"></ion-icon>
                    </span>
                  </button>
                  <button onClick={submit} className="noselect primary">
                    <span className="text">Lưu</span>
                    <span className="icon">
                      <ion-icon size="large" name="save-outline"></ion-icon>
                    </span>
                  </button>
                </>
              )}
              {action === ACTION.OPENFILE && (
                <span onClick={() => downloadFile(currentFile.documentUrl)}>
                  <ion-icon size="large" name="download-outline"></ion-icon>
                </span>
              )}
              {action === ACTION.SUBMITFILE && (
                <button className="btn btn-primary" onClick={submit}>
                  Nộp{" "}
                  <ion-icon size="large" name="cloud-upload-outline"></ion-icon>
                </button>
              )}
            </ModalFooter>
          </Modal>
        )}
      </ModalTransition>
    </div>
  );
};

export default LearnDetailPage;
