import "./assignment.css";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import TagComponent, { TagType } from "../tag/tag.component";
import { ROLE } from "../../consts/role.const";
import { useEffect, useState } from "react";
import { MenuItem, useMenuState, ControlledMenu } from "@szhsin/react-menu";
import "@szhsin/react-menu/dist/core.css";
import "@szhsin/react-menu/dist/index.css";
import { ACTION } from "../../consts/action.const";
import { Link } from "react-router-dom";
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";
import { useSelector } from "react-redux";
const data = {
  assignmentScriptTitle: "Learning ASP.NET",
  assignmentScriptDescription: "Làm bài tập dựa trên mẫu sau",
  status: 0,
  assignmentScriptOpenAt: "2022-04-25",
  assignmentScriptDueTo: "2022-04-26",
};
const AssignmentComponent = ({
  assignment = data,
  toggle,
  isModifiable,
  remove,
  assignmentRef = [],
  removeAssignment,
  submittedResult = [],
  students = [],
  save,
}) => {
  const [menuProps, toggleMenu] = useMenuState();
  const [anchorPoint, setAnchorPoint] = useState({ x: 0, y: 0 });
  const [isOpen, setIsOpen] = useState(false);
  const [action, setAction] = useState("");
  const toggleModal = (action) => {
    setIsOpen(!isOpen);
    setAction(action);
  };
  const [temp, setData] = useState(assignment);
  useEffect(() => {
    setData(assignment);
  }, [assignment]);
  const { account } = useSelector((x) => x.auth);
  const saveData = async (data) => {
    await save(data);
    toggleModal("");
  }
  const {data} = useSelector(x => x.auth);
  return (
    <>
      <div className={isModifiable ? "edit-mode" : ""}>
        <div
          className="assignment"
          onClick={() => {
            if (account.role === ROLE.STUDENT) {
              toggle();
            }
          }}
          onContextMenu={(e) => {
            if(isModifiable){
              e.preventDefault();
              setAnchorPoint({ x: e.clientX, y: e.clientY });
              toggleMenu(true);
            }
          }}
        >
          <h4>Nộp bài</h4>
          <div className="content">
            <div className="header">
              <span>
                <ion-icon size="large" name="cloud-upload-outline"></ion-icon>
              </span>
              <span>{temp.assignmentScriptTitle}</span>
            </div>
            <div>
              <span>{temp.assignmentScriptDescription}</span>
            </div>
            <div className="footer">
              <div>
                {account &&
                account.role === ROLE.STUDENT &&
                assignmentRef.find((x) => x.assignmentId === assignment.id && x.studentId === data.student.id)
                  ? "Đã nộp"
                  : "Chưa nộp"}
              </div>
              {new Date(temp.assignmentScriptDueTo).getTime() <
                new Date().getTime() && (
                <TagComponent type={TagType.IN} name={"Hết hạn"}></TagComponent>
              )}
              <TagComponent
                type={TagType.INFOR}
                name={`Mở từ: ${temp.assignmentScriptOpenAt}`}
              ></TagComponent>
              <TagComponent
                type={TagType.DANGER}
                name={`Hạn: ${temp.assignmentScriptDueTo}`}
              ></TagComponent>
            </div>
            <div className="footer">
              {assignmentRef.find((x) => x.assignmentId === temp.id) && (
                <div></div>
              )}
            </div>
          </div>
          <ControlledMenu
            {...menuProps}
            anchorPoint={anchorPoint}
            onClose={() => toggleMenu(false)}
          >
            <MenuItem onClick={() => toggleModal(ACTION.ASSIGNMENTREPORT)}>
              Chi tiết
            </MenuItem>
            <MenuItem onClick={() => toggleModal(ACTION.EDITSECTION)}>
              Cập nhật
            </MenuItem>
          </ControlledMenu>
          <ModalTransition>
            {isOpen && (
              <Modal
                onClose={toggleModal}
                width={"large"}
                css={{ width: "100%", height: "100%" }}
              >
                <ModalHeader appearance="info">
                  <ModalTitle>
                    {action === ACTION.ASSIGNMENTREPORT && (
                      <h4>Chi tiết nộp bài</h4>
                    )}
                  </ModalTitle>
                </ModalHeader>
                <ModalBody>
                  {action === ACTION.ASSIGNMENTREPORT && (
                    <div className="datatable">
                      <Link target={"_blank"} download to={""}>
                        Tải toàn bộ{" "}
                        <ion-icon
                          size="large"
                          name="download-outline"
                        ></ion-icon>
                      </Link>
                      <table className="table-glassmorphism">
                        <thead>
                          <tr>
                            <th>STT</th>
                            <th>Mã HS/SV</th>
                            <th>Họ và tên</th>
                            <th>Ngày nộp</th>
                            <th></th>
                          </tr>
                        </thead>
                        <tbody>
                          {submittedResult
                            .filter((x) => x.assignmentId === assignment.id)
                            .map((result, idx) => (
                              <tr key={idx}>
                                <td>{idx + 1}</td>
                                <td>
                                  {
                                    students.find(
                                      (x) => x.id === result.studentId
                                    ).studentID
                                  }
                                </td>
                                <td>
                                  {
                                    students.find(
                                      (x) => x.id === result.studentId
                                    ).fullName
                                  }
                                </td>
                                <td>{result.submitDate}</td>
                                <td>
                                  <Link
                                    target={"_blank"}
                                    download
                                    to={result.filePath}
                                  >
                                    <ion-icon
                                      size="large"
                                      name="download-outline"
                                    ></ion-icon>
                                  </Link>
                                </td>
                              </tr>
                            ))}
                        </tbody>
                      </table>
                    </div>
                  )}
                  {action === ACTION.EDITSECTION && (
                    <>
                      <label>Tiêu đề</label>
                      <input
                        type="text"
                        name="title"
                        id="start"
                        className="form-field"
                        defaultValue={data.assignmentScriptTitle}
                        onChange={(e) =>
                          setData({
                            ...data,
                            title: e.target.value,
                          })
                        }
                      />
                      <label>Mô tả</label>
                      <input
                        type="text"
                        name="title"
                        id="start"
                        className="form-field"
                        defaultValue={data.assignmentScriptDescription}
                        onChange={(e) =>
                          setData({
                            ...data,
                            assignmentScriptDescription: e.target.value,
                          })
                        }
                      />
                      <div>
                        <label>Chi tiết</label>
                        <textarea
                          type="date"
                          name="assignmentScriptDescription"
                          id="tutorial"
                          className="form-field"
                          defaultValue={data.detail}
                          onChange={(e) =>
                            setData({
                              ...data,
                              detail: e.target.value,
                            })
                          }
                        ></textarea>

                        <label>Thời gian mở</label>
                        <input
                          type="date"
                          name="assignmentScriptOpenAt"
                          id="start"
                          className="form-field"
                          defaultValue={data.assignmentScriptOpenAt}
                          onChange={(e) =>
                            setData({
                              ...data,
                              assignmentScriptOpenAt: e.target.value,
                            })
                          }
                        />
                        <label>Thời gian đóng</label>
                        <input
                          type="date"
                          name="assignmentScriptDueTo"
                          id="end"
                          className="form-field"
                          defaultValue={data.assignmentScriptDueTo}
                          onChange={(e) =>
                            setData({
                              ...data,
                              assignmentScriptDueTo: e.target.value,
                            })
                          }
                        />
                      </div>
                    </>
                  )}
                </ModalBody>
                <ModalFooter>
                  {action === ACTION.EDITSECTION && (
                    <div>
                      <button
                        onClick={() => saveData(data)}
                        className="noselect primary"
                      >
                        <span className="text">Lưu</span>
                        <span className="icon">
                          <ion-icon size="large" name="save-outline"></ion-icon>
                        </span>
                      </button>
                    </div>
                  )}
                </ModalFooter>
              </Modal>
            )}
          </ModalTransition>
        </div>
        {isModifiable && (
          <div className="remove">
            <ion-icon
              size="large"
              onClick={() => remove(assignment)}
              name="trash-outline"
            ></ion-icon>
          </div>
        )}
      </div>
    </>
  );
};

export default AssignmentComponent;
