import { useEffect, useState, useMemo, useRef } from "react";
import TagComponent, { TagType } from "../../components/tag/tag.component";
import "./ticket.css";
import {
  Chart as ChartJS,
  ArcElement,
  LinearScale,
  CategoryScale,
  BarElement,
  PointElement,
  LineElement,
  Tooltip,
  Legend,
} from "chart.js";
import { Doughnut } from "react-chartjs-2";
import { Chart } from "react-chartjs-2";
import faker from "faker";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import LoadingComponent from "../../components/loading/loading.component";
import { TICKETSTATUS, TICKETTYPE } from "../../consts/tickettype.const";
import JoditEditor from "jodit-react";
import SunEditor from "suneditor-react";
import parse from "html-react-parser";
import "suneditor/dist/css/suneditor.min.css"; // Import Sun Editor's CSS File

import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";
import axiosClient from "../../global/axios/axiosClient";
import { useSelector } from "react-redux";
import { ACTION } from "../../consts/action.const";
import { ROLE } from "../../consts/role.const";
ChartJS.register(
  ArcElement,
  LinearScale,
  CategoryScale,
  BarElement,
  PointElement,
  LineElement,
  Tooltip,
  Legend
);
export const data = {
  labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
  datasets: [
    {
      label: "# of Votes",
      data: [12, 19, 3, 5, 2, 3],
      backgroundColor: [
        "rgba(255, 99, 132, 0.2)",
        "rgba(54, 162, 235, 0.2)",
        "rgba(255, 206, 86, 0.2)",
        "rgba(75, 192, 192, 0.2)",
        "rgba(153, 102, 255, 0.2)",
        "rgba(255, 159, 64, 0.2)",
      ],
      borderColor: [
        "rgba(255, 99, 132, 1)",
        "rgba(54, 162, 235, 1)",
        "rgba(255, 206, 86, 1)",
        "rgba(75, 192, 192, 1)",
        "rgba(153, 102, 255, 1)",
        "rgba(255, 159, 64, 1)",
      ],
      borderWidth: 1,
    },
  ],
};
const labels = ["January", "February", "March", "April", "May", "June", "July"];

export const data2 = {
  labels,
  datasets: [
    {
      type: "line",
      label: "Dataset 1",
      borderColor: "rgb(255, 99, 132)",
      borderWidth: 2,
      fill: false,
      data: labels.map(() => faker.datatype.number({ min: -1000, max: 1000 })),
    },
    {
      type: "bar",
      label: "Dataset 2",
      backgroundColor: "rgb(75, 192, 192)",
      data: labels.map(() => faker.datatype.number({ min: -1000, max: 1000 })),
      borderColor: "white",
      borderWidth: 2,
    },
    {
      type: "bar",
      label: "Dataset 3",
      backgroundColor: "rgb(53, 162, 235)",
      data: labels.map(() => faker.datatype.number({ min: -1000, max: 1000 })),
    },
  ],
};
const ticketData = [
  {
    id: 0,
    title: "Xin nghi hoc ngay 22/3",
    status: "Pending",
    supervisor: "Ms. Le Thi Minh Chau",
    detail: "Vi hom nay em bi om nen em xin phep nghi hoc",
  },
  {
    id: 1,
    title: "Xin nghi hoc ngay 24/3",
    status: "Approved",
    supervisor: "Ms. Le Thi Minh Chau",
    detail: "Vi hom nay em bi om nen em xin phep nghi hoc",
  },
  {
    id: 2,
    title: "Xin nghi hoc ngay 26/3",
    status: "Approved",
    supervisor: "Ms. Le Thi Minh Chau",
    detail: "Vi hom nay em bi om nen em xin phep nghi hoc",
  },
];
const TicketPage = () => {
  const editor = useRef(null);
  const [content, setContent] = useState("");
  const config = {
    readonly: false, // all options from https://xdsoft.net/jodit/doc/,
    placeholder: "Start typings...",
    textAlign: "left",
  };
  const [tickets, setTickets] = useState([...ticketData]);
  const [currentStatus, setCurrentStatus] = useState(TICKETSTATUS.NEW);
  const [currentTicket, setCurrentTicket] = useState(null);
  const [isSelectTicketLoading, setIsSelectTicketLoading] = useState({
    status: false,
    ticket: null,
  });
  const [isReload, setIsReload] = useState(false);
  useEffect(() => {
    let isMounted = true;
    let abortController = new AbortController();
    //Calling api here
    return () => {
      isMounted = false;
      abortController.abort();
    };
  });
  const [ticket, setTicket] = useState({
    ticketType: "ABSENT",
  });
  const valueChange = (e) => {
    console.log(e.target.value);
    setTicket({
      ...ticket,
      [e.target.name]: e.target.value,
    });
  };
  const updateValueChange = (e) => {
    setCurrentTicket({
      ...currentTicket,
      [e.target.name]: e.target.value,
    });
  };
  const submitCreate = () => {
    console.log(ticket);
  };
  let modalFired = false;
  const MySwal = withReactContent(Swal);
  const [isOpen, setIsOpen] = useState(false);
  const [action, setAction] = useState("");
  const [teachers, setTeachers] = useState([]);
  const { account } = useSelector((x) => x.auth);
  const { student } = useSelector((x) => x.auth.data);
  useEffect(() => {
    let isMounted = true;
    let abortController = new AbortController();
    //Calling api here
    const fetchData = async () => {
      let url = `/api/crm/ticket?accountId=${account.id}&status=${currentStatus}`;
      if (account.role === ROLE.TEACHER) {
        url += `&isTeacher=true`;
      }
      const result = await axiosClient.get(url);
      console.log(result);
      setTickets(result);
      if (account && student && account?.role === ROLE.STUDENT) {
        const avail = await axiosClient.get(
          `/api/course/availableteacher?id=${student.id}`
        );
        console.log(avail);
        setTeachers(avail.data);
      }
    };
    fetchData();
    return () => {
      isMounted = false;
      abortController.abort();
    };
  }, [isReload, currentStatus, account, student]);
  useEffect(() => {
    if (action !== "") {
      setIsOpen(true);
    } else {
      setIsOpen(false);
    }
  }, [action, setAction]);

  const toggleModal = () => {
    if (action !== "" && isOpen) {
      setAction("");
    }
    setIsOpen(!isOpen);
  };
  const selectTicket = (ticket) => {
    setIsSelectTicketLoading({ status: true, ticket: ticket });
  };
  const submit = async () => {
    switch (action) {
      case ACTION.CREATE:
        console.log("Thêm thành công");
        console.log(ticket);
        const data = {
          ...ticket,
          ownerId: account.id,
          ownerUsername: account.username,
        };
        const createResult = await axiosClient.post("/api/crm/ticket", data);
        console.log(createResult);
        break;
      case ACTION.EDIT:
        console.log(currentTicket);
        console.log("Cập nhật thành công");
        const updateResult = await axiosClient.put(
          `/api/crm/ticket/${currentTicket.id}`,
          currentTicket
        );
        console.log(updateResult);
        break;
      case ACTION.DELETE:
        console.log("Xóa thành công");
        console.log(currentTicket);
        const deleteResult = await axiosClient.delete(
          `/api/crm/ticket/${currentTicket.id}`
        );
        console.log(deleteResult);
        break;
      default:
        break;
    }
    setIsReload(!isReload);
    toggleModal();
  };
  const approve = async (ticket) => {
    console.log(ticket);
    ticket.status = TICKETSTATUS.APPROVED;
    const result = await axiosClient.put(
      `/api/crm/Ticket/${ticket.id}`,
      ticket
    );
    console.log(result);
    if (result.status === 200) {
      setIsReload(!isReload);
    }
  };
  const decline = async (ticket) => {
    ticket.status = TICKETSTATUS.DECLINED;
    const result = await axiosClient.put(
      `/api/crm/Ticket/${ticket.id}`,
      ticket
    );
    console.log(result);
    if (result.status === 200) {
      setIsReload(!isReload);
    }
  };
  return (
    <div className="ticket-page">
      <div className="current-tickets">
        {account && account.role === ROLE.STUDENT && (
          <button
            className="btn btn-primary"
            onClick={() => setAction(ACTION.CREATE)}
          >
            Tạo phiếu
            <span>
              <ion-icon size="large" name="ticket-outline"></ion-icon>
            </span>
          </button>
        )}
        <select
          onChange={(e) => setCurrentStatus(e.target.value)}
          className="form-field w-25"
        >
          <option value={TICKETSTATUS.NEW}>Mới</option>
          <option value={TICKETSTATUS.APPROVED}>Đã duyệt</option>
          <option value={TICKETSTATUS.DECLINED}>Từ chối</option>
        </select>
        <table>
          <thead>
            <tr>
              <th>Mã</th>
              <th>Loại phiếu</th>
              <th>Tiêu đề</th>
              <th>Trạng thái</th>
              <th>Ngày tạo</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {tickets.map((t, idx) => (
              <tr key={idx}>
                <td className="clickable" onClick={() => selectTicket(t)}>
                  PYC-{idx}
                </td>
                <td>
                  <TagComponent type={TagType.INFOR} name="Phép"></TagComponent>
                </td>
                <td className="clickable" onClick={() => selectTicket(t)}>
                  {t.title}
                </td>
                <td>
                  <TagComponent
                    type={TagType.INFOR}
                    name={t.status}
                  ></TagComponent>
                </td>
                <td>{t.createDate}</td>
                <td className="d-flex">
                  {t.status === TICKETSTATUS.NEW &&
                    account.role === ROLE.STUDENT && (
                      <>
                        <button
                          className="btn btn-warning"
                          onClick={() => {
                            setAction(ACTION.EDIT);
                            setCurrentTicket(t);
                          }}
                        >
                          Sửa
                        </button>
                        <button
                          className="btn btn-danger"
                          onClick={() => {
                            setAction(ACTION.DELETE);
                            setCurrentTicket(t);
                          }}
                        >
                          Xóa
                        </button>
                      </>
                    )}
                  {account &&
                    account.role === ROLE.TEACHER &&
                    t.status === TICKETSTATUS.NEW && (
                      <>
                        <button
                          onClick={() => approve(t)}
                          className="btn btn-primary"
                        >
                          Duyệt
                        </button>
                        <button
                          onClick={() => decline(t)}
                          className="btn btn-danger"
                        >
                          Từ chối
                        </button>
                      </>
                    )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <div>1 - 3 of 3</div>
      </div>
      <div className="navigation">
        <div className="box-1">
          {isSelectTicketLoading.status ? (
            <LoadingComponent
              type={"circle"}
              timelapse={1000}
              end={() => {
                setCurrentTicket(isSelectTicketLoading.ticket);
                setIsSelectTicketLoading({ status: false });
              }}
            ></LoadingComponent>
          ) : !currentTicket ? (
            "Chọn phiếu để xem chi tiết"
          ) : (
            <div className="ticket-detail">
              <p>Tiêu đề: {currentTicket.title}</p>
              <p>Chi tiết {parse(currentTicket.detail)}</p>
              <p>Từ ngày: {currentTicket.fromDate}</p>
              <p>Đến ngày: {currentTicket.toDate}</p>
            </div>
          )}
        </div>
        <div className="box-2">
          <Doughnut data={data}></Doughnut>
        </div>
      </div>
      <ModalTransition>
        {isOpen && (
          <Modal>
            <ModalHeader>
              <ModalTitle>Thêm phiếu</ModalTitle>
            </ModalHeader>
            <ModalBody>
              <div>
                <form className="form">
                  {action === ACTION.CREATE && (
                    <>
                      <div className="form-group">
                        <label>Loại phiếu (*)</label>
                        <select
                          defaultValue={TICKETTYPE.ABSENT}
                          onChange={(e) => valueChange(e)}
                          name="ticketType"
                          className="form-field"
                        >
                          {Object.keys(TICKETTYPE).map((type, idx) => (
                            <option key={idx} value={type}>
                              {TICKETTYPE[type]}
                            </option>
                          ))}
                        </select>
                      </div>
                      <div className="form-group">
                        <label>Tiêu đề phiếu (*)</label>
                        <input
                          onChange={(e) => valueChange(e)}
                          name="title"
                          type="text"
                          className="form-field"
                          placeholder="VD: Xin phép nghỉ học"
                        />
                      </div>
                      <div className="form-group">
                        <label>Nội dung phiếu (*)</label>
                        <SunEditor
                          name="detail"
                          height="100%"
                          onChange={(e) =>
                            setTicket({
                              ...ticket,
                              detail: e,
                            })
                          }
                        />
                      </div>
                      <div className="form-group">
                        <label>Người phê duyệt</label>
                        <select
                          onChange={(e) => valueChange(e)}
                          name="supervisorId"
                          className="form-field"
                        >
                          {teachers.map((teacher, idx) => (
                            <option
                              selected={idx === 0}
                              value={teacher.id}
                              key={idx}
                            >
                              {teacher.fullName} - {teacher.teacherID}
                            </option>
                          ))}
                        </select>
                      </div>
                      <div className="form-group">
                        <label>Ngày bắt đầu</label>
                        <input
                          onChange={(e) => valueChange(e)}
                          name="fromDate"
                          type="date"
                          className="form-field"
                        />
                      </div>
                      <div className="form-group">
                        <label>Ngày kết thúc</label>
                        <input
                          onChange={(e) => valueChange(e)}
                          name="toDate"
                          type="date"
                          className="form-field"
                        />
                      </div>
                    </>
                  )}
                  {action === ACTION.EDIT && (
                    <>
                      <div className="form-group">
                        <label>Tiêu đề phiếu (*)</label>
                        <input
                          onChange={(e) => updateValueChange(e)}
                          name="title"
                          type="text"
                          className="form-field"
                          placeholder="VD: Xin phép nghỉ học"
                          defaultValue={currentTicket.title}
                        />
                      </div>
                      <div className="form-group">
                        <label>Nội dung phiếu (*)</label>
                        <SunEditor
                          name="detail"
                          height="100%"
                          onChange={(e) =>
                            setCurrentTicket({
                              ...currentTicket,
                              detail: e,
                            })
                          }
                          defaultValue={currentTicket.detail}
                        />
                      </div>
                      <div className="form-group">
                        <label>Người phê duyệt</label>
                        <input
                          onChange={(e) => updateValueChange(e)}
                          name="supervisorId"
                          type="text"
                          className="form-field"
                          defaultValue={currentTicket.supervisorId}
                        />
                      </div>
                      <div className="form-group">
                        <label>Ngày bắt đầu</label>
                        <input
                          onChange={(e) => updateValueChange(e)}
                          name="fromDate"
                          type="date"
                          className="form-field"
                          defaultValue={currentTicket.fromDate}
                        />
                      </div>
                      <div className="form-group">
                        <label>Ngày kết thúc</label>
                        <input
                          onChange={(e) => updateValueChange(e)}
                          name="toDate"
                          type="date"
                          className="form-field"
                          defaultValue={currentTicket.toDate}
                        />
                      </div>
                    </>
                  )}
                  {action === ACTION.DELETE && (
                    <div>Bạn có chắc chắn xóa PYC này không?</div>
                  )}
                </form>
              </div>
            </ModalBody>
            <ModalFooter>
              <button className="btn btn-secondary" onClick={toggleModal}>
                Hủy
              </button>
              <button className="btn btn-primary" onClick={submit}>
                Lưu
              </button>
            </ModalFooter>
          </Modal>
        )}
      </ModalTransition>
    </div>
  );
};

export default TicketPage;
