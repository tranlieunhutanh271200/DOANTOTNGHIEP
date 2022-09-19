import { useEffect, useState } from "react";
import TagComponent, { TagType } from "../../components/tag/tag.component";
import Moment from "react-moment";
import "./logwork.css";
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
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";

import { TASKSTATUS } from "../../consts/taskstatus.const";
import { ACTION } from "../../consts/action.const";
import axiosClient from "../../global/axios/axiosClient";
import { useSelector } from "react-redux";
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
const localData = [
  {
    id: 1,
    taskName: "Test task 1",
    description: "test test",
    status: TASKSTATUS.TODO,
    startAt: "2022-05-16",
    dueTo: "2022-05-18",
    totalSpent: 6,
  },
  {
    id: 2,
    taskName: "Test task 2",
    description: "test test",
    status: TASKSTATUS.PROCESS,
    startAt: "2022-05-16",
    dueTo: "2022-05-18",
    totalSpent: 6,
  },
  {
    id: 3,
    taskName: "Test task 3",
    description: "test test",
    status: TASKSTATUS.DONE,
    startAt: "2022-05-16",
    dueTo: "2022-05-18",
    totalSpent: 6,
  },
];
const LogworkPage = () => {
  const [tasks, setTasks] = useState([]);
  const [status, setStatus] = useState(TASKSTATUS.PROCESS);
  const [refreshFlag, setRefreshFlag] = useState(false);
  useEffect(() => {
    const fetchData = async () => {
      const tasks = await axiosClient.get(
        `/api/crm/task?accountId=${account.id}&taskStatus=${status}`
      );
      console.log(tasks);
      setTasks(tasks.filter(x => x.status === TASKSTATUS.PROCESS));
    };
    fetchData();
  }, [refreshFlag]);
  const { account } = useSelector((x) => x.auth);
  const [logwork, setLogwork] = useState({
    duration: 1,
  });
  const valueChange = (e) => {
    setLogwork({
      ...logwork,
      [e.target.name]: e.target.value,
    });
  };
  const crudValueChange = (e) => {
    setTask({
      ...task,
      [e.target.name]: e.target.value,
    });
  };
  const [task, setTask] = useState({});
  const [action, setAction] = useState("");
  const [isOpen, setIsOpen] = useState(false);

  const toggleModal = (act, selectTask) => {
    if (action !== "" && isOpen) {
      setAction("");
    }
    if (act === ACTION.CREATE) {
      setTask({});
    } else {
      setTask(selectTask);
    }
    setIsOpen(!isOpen);
    setAction(act);
  };
  const submit = async () => {
    switch (action) {
      case ACTION.LOGWORK:
        console.log("logwork", logwork);

        console.log("task", task);
        var data ={
          ...logwork,
          taskId: task.id
        }

        var result = await axiosClient.put(
          `/api/crm/task/${task.id}/logwork`,
          data
        );
        console.log(result);
        break;
      case ACTION.RESETLOGWORK:
        console.log("logwork", task);
        var result = await axiosClient.delete(
          `/api/crm/task/${task.id}/logwork`
        );
        console.log(result);
        break;
      default:
        break;
    }
    setLogwork({ duration: 1 });
    setIsOpen(false);
    setRefreshFlag(!refreshFlag);
  };

  return (
    <div className="logwork-page">
      <div className="main-tab">
        <table className="beautiful-table">
          <thead>
            <tr>
              <th>Mã</th>
              <th>Tên task</th>
              <th>Trạng thái</th>
              <th>Ngày bắt đầu</th>
              <th>Ngày kết thúc</th>
              <th>Tổng thời gian</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {tasks.map((task, idx) => (
              <tr key={idx}>
                <td
                  className="loggable"
                  onClick={() => toggleModal(ACTION.LOGWORK, task)}
                >
                  {idx + 1}
                </td>
                <td
                  className="loggable"
                  onClick={() => toggleModal(ACTION.LOGWORK, task)}
                >
                  {task.taskName}
                </td>
                <td>
                  <TagComponent name={task.status}></TagComponent>
                </td>
                <td>
                  <Moment format="DD/MM/YYYY">{task.startAt}</Moment>
                </td>
                <td>
                  <Moment format="DD/MM/YYYY">{task.dueTo}</Moment>
                </td>
                <td>{task.totalSpent} giờ</td>
                <td>
                  <ion-icon
                    size="large"
                    onClick={() => toggleModal(ACTION.RESETLOGWORK, task)}
                    name="refresh-circle-outline"
                  ></ion-icon>
                  <ion-icon
                    size="large"
                    onClick={() => toggleModal(ACTION.LOGWORK, task)}
                    name="create-outline"
                  ></ion-icon>
                </td>
              </tr>
            ))}
            <tr>
              <td>
                Display {tasks.length}/{tasks.length}
              </td>
            </tr>
          </tbody>
        </table>
        {/* <div className="beautiful-table">
          Detail task here (select task to see)
        </div> */}
      </div>
      <div className="additional-tab">
        <div className="tab-1">
          <Doughnut data={data}></Doughnut>
        </div>
        <div className="tab-2">
          <Chart type="bar" data={data2} />
        </div>
      </div>
      <ModalTransition>
        {isOpen && (
          <Modal onClose={() => toggleModal()}>
            <ModalHeader>
              <ModalTitle>{action === ACTION.CREATE}</ModalTitle>
            </ModalHeader>
            <ModalBody>
              <div>
                <form className="form">
                  {action === ACTION.RESETLOGWORK && (
                    <div>
                      <h2 className="text-info">
                        Bạn có chắc chắn reset log work task này trong hôm nay
                      </h2>
                      <h3>Không thể hoàn tác</h3>
                    </div>
                  )}
                  {action === ACTION.LOGWORK && (
                    <>
                      <div className="align-center">
                        Log work cho task {task.taskName}
                      </div>
                      <div className="form-group">
                        <label>Thời gian làm task</label>
                        <input
                          onChange={(e) => valueChange(e)}
                          name="duration"
                          className="form-field"
                          placeholder="Thời gian làm (giờ)"
                          type="number"
                          min={1}
                          max={8}
                          defaultValue={1}
                        />
                      </div>
                      <div className="form-group">
                        <label>Mô tả</label>
                        <input
                          onChange={(e) => valueChange(e)}
                          name="description"
                          className="form-field"
                          placeholder="Mô tả"
                          type="text"
                        />
                      </div>
                    </>
                  )}
                </form>
              </div>
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

export default LogworkPage;
