import { useState } from "react";
import "./exam.css";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { Link } from "react-router-dom";
import { useHistory } from "react-router-dom";
import DataTableComponent from "../../../components/datatable/datatable.component";
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";
import { ACTION } from "../../../consts/action.const";
const examData = [
  {
    id: "2642828a-489e-4066-38ad-08da362d8797",
    title: 'Test exam',
    description: "Test exam",
    duration: 0,
    totalQuestions: 3
  }
];
const ExamPage = () => {
  const [examHistories, setExamHistories] = useState([]);
  const { location } = useHistory();
  const MySwal = withReactContent(Swal);
  const [addExam, setAddExam] = useState({})
  const [currentExam, setCurrentExam] = useState(null);
  const [action, setAction] = useState('');
  const [isOpen, setIsOpen] = useState(false);
  const toggleModal = (action) => {
    setAction(action);
    setIsOpen(!isOpen);
  }
  const submit = async () => {
    switch (action) {
      case ACTION.CREATE:

        break;
      case ACTION.EDIT:
        break;
      case ACTION.DELETE:
        break;
      default:
        break;
    }
  }
  return (
    <div className="exam-page">
      12312
      <Link to={`${location.pathname}/1/2`}>
        do
      </Link>
      <DataTableComponent
        rows={examData}
        headerTitle={"Exam manager"}
        idColumn="id"
        headers={['Tiêu đề', 'Mô tả', 'Thời gian làm bài', 'Số câu hỏi']}
        hideColumns={"id"}
        isAddable={true}
        isDeleteable={true}
        isEditable={true}
        openAddModal={() => toggleModal(ACTION.CREATE)}
        openEditModal={(e) => {
          toggleModal(ACTION.EDIT);
          setCurrentExam(e);
        }}
        openDeleteModal={(e) => {
          toggleModal(ACTION.DELETE);
          setCurrentExam(e);
        }}>

      </DataTableComponent>
      <ModalTransition>
        {isOpen && (
          <Modal onClose={toggleModal}>
            <ModalHeader>
              <ModalTitle>
                {action === ACTION.CREATE && 'Thêm bài kiểm tra'}
                {action === ACTION.EDIT && 'Sửa bài kiểm tra'}
                {action === ACTION.DELETE && 'Xoá bài kiểm tra'}
              </ModalTitle>
            </ModalHeader>
            <ModalBody>
              <form>
                {action === ACTION.CREATE && 
                <>
                  <div className="form-group">
                    <label htmlFor="">Tiêu đề</label>
                    <input name='title' type="text" className="form-field" />
                  </div>
                  <div className="form-group">
                    <label htmlFor="">Thời gian làm bài (phút)</label>
                    <input type="number" defaultValue={15} min={15} name="duration" className="form-field" />
                  </div>
                  <div className="form-group">
                    <label htmlFor=""></label>
                  </div>
                </>}
              </form>
            </ModalBody>
          </Modal>
        )} </ModalTransition>
    </div>
  );
};

export default ExamPage;
