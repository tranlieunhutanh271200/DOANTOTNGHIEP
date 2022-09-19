import TaskSummaryComponent from "../../../components/task-summary/task-summary.comnponent";
import "./task-manage.css";
const TaskManagePage = () => {
  return (
    <div className="task-manage-page">
      <div className="filter">
        <select className="form-field">
          <option>Lớp 18110CL3A</option>
          <option>Lớp 18110CL3B</option>
          <option>Lớp 18110CL3C</option>
        </select>
        <select className="form-field">
          <option>Nhựt Anh</option>
          <option>Ngọc Như</option>
          <option>Thành Như</option>
        </select>
        <input type='date' placeholder="Từ ngày" className="form-field" />
        
      </div>
      <div className="detail">
        <TaskSummaryComponent></TaskSummaryComponent>
      </div>
    </div>
  );
};

export default TaskManagePage;
