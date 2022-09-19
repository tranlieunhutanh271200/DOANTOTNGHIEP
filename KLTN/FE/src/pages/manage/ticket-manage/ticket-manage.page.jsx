import { useEffect, useState } from "react";
import DataTableComponent from "../../../components/datatable/datatable.component";
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";
import { ACTION } from "../../../consts/action.const";
import axiosClient from "../../../global/axios/axiosClient";
import "./ticket-manage.css";
import { ROLE } from "../../../consts/role.const";
const ticketData = [
  {
    title: "Xin nghỉ học 2",
    ownerId: "b36c2a83-aabd-40c3-6b72-08da3503ce41",
    ownerUsername: "nhutanh",
    ownerFullname: "Tran Lieu Nhut Anh",
    class: '18110CL3A',
    ownerEmail: null,
    ticketType: 0,
    toDate: "2022-05-22T10:04:18.528",
    createDate: '2022-05-22',
    detail: "string",
    supervisorId: "e234b73c-d762-403e-6b73-08da3503ce41",
    status: 0,
  },
  {
    title: "Xin nghỉ học 3",
    ownerId: "b36c2a83-aabd-40c3-6b72-08da3503ce41",
    ownerUsername: "nhutanh",
    ownerFullname: "Tran Lieu Nhut Anh",
    class: '18110CL3A',
    ownerEmail: null,
    ticketType: 0,
    toDate: "2022-05-22T10:04:18.528",
    createDate: '2022-05-22',
    detail: "string",
    supervisorId: "e234b73c-d762-403e-6b73-08da3503ce41",
    status: 0,
  },
];
const TicketManagePage = () => {
  const [action, setAction] = useState("");
  const [ticket, setTicket] = useState({});
  const [currentTicket, setCurrenTicket] = useState({});
  const [isOpen, setIsOpen] = useState(false);
  useEffect(() => {
    if (action !== "") {
      setIsOpen(true);
    }
  }, [action, setAction]);
  const submit = () => {
      console.log("submit");
  }
  const toggleModal = () => {
    if (action !== "" && isOpen) {
      setAction("");
    }
    setIsOpen(!isOpen);
  };
  const role = ROLE.TEACHER;
  return (
    <div className="ticket-manage-page">
      {role === ROLE.TEACHER && (
        <DataTableComponent
          rows={ticketData.filter(x => x.status === 0)}
          headers={[
            "Tiêu đề phiếu",
            "Người tạo",
            "Lớp",
            "Trạng thái",
            "Loại phiếu",
            "Ngày tạo",
          ]}
          headerTitle={"Quản lý PYC"}
          idColumn="id"
          hideColumns={[
            "id",
            "ownerId",
            "ownerUsername",
            "ownerEmail",
            "toDate",
            "supervisorId",
            "detail"
          ]}
        ></DataTableComponent>
      )}
        <ModalTransition>
        {isOpen && (
          <Modal onClose={toggleModal}>
            <ModalHeader>
              <ModalTitle>{action === ACTION.CREATE}</ModalTitle>
            </ModalHeader>
            <ModalBody>
                {action === ACTION.CREATE && <>
                    Tạo phiếu
                </>}
                {action === ACTION.EDIT && <>
                    Chỉnh sửa phiếu
                </>}
                {action === ACTION.DELETE && <>
                    Xóa phiếu
                </>}
            </ModalBody>
            <ModalFooter>
            </ModalFooter>
          </Modal>
        )}
      </ModalTransition>
    </div>
  );
};

export default TicketManagePage;
