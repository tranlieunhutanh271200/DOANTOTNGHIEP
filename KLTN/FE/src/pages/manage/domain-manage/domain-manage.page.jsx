import DataTableComponent from "../../../components/datatable/datatable.component";
import { ROLE } from "../../../consts/role.const";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { DOMAINSTATUS } from "../../../consts/domainstatus.const";
import TagComponent, { TagType } from "../../../components/tag/tag.component";
import { useEffect, useState } from "react";
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";

import { ACTION } from "../../../consts/action.const";
import axiosClient from "../../../global/axios/axiosClient";
import CheckListComponent from "../../../components/checklist/checklist.component";
import { Link } from "react-router-dom";
import connection from "../../../services/signalr.service";
import { useSelector } from "react-redux";
const componentData = [
  {
    id: 1,
    componentName: "HR Manage",
    componentEndpoint: "/manage-hr",
    componentLogo: "people-outline",
  },
  {
    id: 2,
    componentName: "Task Manage",
    componentEndpoint: "/manage-task",
    componentLogo: "clipboard-outline",
  },
  {
    id: 3,
    componentName: "Ticket Manage",
    componentEndpoint: "/manage-ticket",
    componentLogo: "ticket-outline",
  },
  {
    id: 4,
    componentName: "Domain Manage",
    componentEndpoint: "/manage-domain",
    componentLogo: "business-outline",
  },
];
const domainData = [
  {
    id: 1,
    schoolName: "Ho Chi Minh City University of Technology and Education",
    abbreviation: "HCMUTE",
    status: "NEW",
    schoolEmail: "minhchau@hcmute.edu.vn",
    domainAdminId: "123",
    domainComponents: [
      {
        id: 1,
        componentName: "HR Manage",
        componentEndpoint: "/manage-hr",
        componentLogo: "people-outline",
      },
      {
        id: 2,
        componentName: "Task Manage",
        componentEndpoint: "/manage-task",
        componentLogo: "clipboard-outline",
      },
    ],
  },
  {
    id: 2,
    schoolName: "Ho Chi Minh City University of Technology",
    abbreviation: "HCMUTE",
    status: "REVIEW",
    schoolEmail: "test@hcmut.edu.vn",
    domainAdminId: "123",
    domainComponents: [
      {
        id: 1,
        componentName: "HR Manage",
        componentEndpoint: "/manage-hr",
        componentLogo: "people-outline",
      },
      {
        id: 2,
        componentName: "Task Manage",
        componentEndpoint: "/manage-task",
        componentLogo: "clipboard-outline",
      },
      {
        id: 3,
        componentName: "Ticket Manage",
        componentEndpoint: "/manage-ticket",
        componentLogo: "ticket-outline",
      },
      {
        id: 4,
        componentName: "Domain Manage",
        componentEndpoint: "/manage-domain",
        componentLogo: "business-outline",
      },
    ],
  },
  {
    id: 3,
    schoolName: "Ho Chi Minh City University of Education",
    abbreviation: "HCMUTE",
    status: "APPROVED",
    schoolEmail: "test2@hcmue.edu.vn",
    domainAdminId: "123",
    domainComponents: [
      {
        id: 1,
        componentName: "HR Manage",
        componentEndpoint: "/manage-hr",
        componentLogo: "people-outline",
      },
      {
        id: 2,
        componentName: "Task Manage",
        componentEndpoint: "/manage-task",
        componentLogo: "clipboard-outline",
      },
      {
        id: 3,
        componentName: "Ticket Manage",
        componentEndpoint: "/manage-ticket",
        componentLogo: "ticket-outline",
      },
      {
        id: 4,
        componentName: "Domain Manage",
        componentEndpoint: "/manage-domain",
        componentLogo: "business-outline",
      },
    ],
  },
  {
    id: 3,
    schoolName: "Ho Chi Minh City University of Transport",
    abbreviation: "UT-HCMC",
    status: "DECLINED",
    schoolEmail: "test2@hcmue.edu.vn",
    domainAdminId: "123",
    domainComponents: [
      {
        id: "a5664ae0-d938-4cee-9267-4309aba108ad",
        componentName: "HR Manage",
        componentEndpoint: "/manage-hr",
        componentLogo: "people-outline",
      },
      {
        id: "15664ae0-d938-4cee-9267-4309aba108ad",
        componentName: "Task Manage",
        componentEndpoint: "/manage-task",
        componentLogo: "clipboard-outline",
      },
      {
        id: "b5664ae0-d938-4cee-9267-4309aba108ad",
        componentName: "Ticket Manage",
        componentEndpoint: "/manage-ticket",
        componentLogo: "ticket-outline",
      },
      {
        id: "c5664ae0-d938-4cee-9267-4309aba108ad",
        componentName: "Domain Manage",
        componentEndpoint: "/manage-domain",
        componentLogo: "business-outline",
      },
    ],
  },
];
const DomainManagePage = () => {
  const role = ROLE.DOMAIN_MANAGER;
  const {account, isRefresh} = useSelector(x => x.auth);
  console.log(account);
  const [domains, setDomains] = useState([]);
  const [domain, setDomain] = useState({});
  const [currentDomain, setCurrentDomain] = useState({});
  const [isReload,setIsReload] = useState(false);
  const [availableComponent, setAvailableComponent] = useState([
    ...componentData,
  ]);
  const editValueChange = (e) => {
    setCurrentDomain({
      ...currentDomain,
      [e.target.name]: e.target.value,
    });
  };
  const createValueChange = (e, isFile = false) => {
    if (isFile) {
      setDomain({
        ...domain,
        file: e.target.files[0],
      });
    } else {
      setDomain({
        ...domain,
        [e.target.name]: e.target.value,
      });
    }
  };
  const [action, setAction] = useState("");
  const [isOpen, setIsOpen] = useState(false);
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
  useEffect(() => {
    const fetchData = async () => {
      var result = await axiosClient.get("/api/Identity/domain");
      console.log(result);
      if (result) {
        setDomains(result);
      }
    };
    fetchData();
  }, [isReload, isRefresh]);
  const submit = async () => {
    switch (action) {
      case ACTION.CREATE:
        console.log("create", domain);
        const form = new FormData();
        Object.keys(domain).forEach((key, idx) => {
          form.append(key, domain[key]);
        });
        var result = await axiosClient.post("/api/Identity/domain", form);
        console.log(result);
        break;
      case ACTION.EDIT:
        console.log("edit", currentDomain);
        const formedit = new FormData();
        Object.keys(domain).forEach((key, idx) => {
          formedit.append(key, domain[key]);
        });
        // var result = await axiosClient.put(
        //   `/api/Identity/domain/${currentDomain.id}`,
        //   formedit
        // );
        // console.log(result);
        if(result.status === 200){
          setIsReload(true);
        }
        break;
      case ACTION.DELETE:
        console.log("delete", currentDomain);
        var result = await axiosClient.delete(
          `/api/Identity/domain/${currentDomain.id}`
        );
        console.log(result);
        if(result.status === 200){
          setIsReload(true);
        }
        break;
      case ACTION.IMPORT:
        console.log("delete", domain);
        break;
      case ACTION.CONFIRMAPPROVED:
        currentDomain.domainStatus = DOMAINSTATUS.APPROVED;
        const formApproved = new FormData();
        Object.keys(currentDomain).forEach((key, idx) => {
          formApproved.append(key, currentDomain[key]);
        });
        var result = await axiosClient.put(
          `/api/identity/domain/${currentDomain.id}`,
          currentDomain
        );
        console.log(result);
        if(result.status === 200){
          setIsReload(true);
        }
        break;
      case ACTION.CONFIRMDECLINED:
        currentDomain.domainStatus = DOMAINSTATUS.DECLINED;
          console.log(currentDomain);
        const formDeclined = new FormData();
        Object.keys(currentDomain).forEach((key, idx) => {
          formDeclined.append(key, currentDomain[key]);
        });
        var result = await axiosClient.put(
          `/api/identity/domain/${currentDomain.id}`,
          currentDomain
        );
        console.log(result);
        if(result.status === 200){
          setIsReload(true);
        }
        break;
      case ACTION.CONFIRMREVIEW:
        console.log(currentDomain);
        currentDomain.domainStatus = DOMAINSTATUS.REVIEW;
        const formRv = new FormData();
        Object.keys(currentDomain).forEach((key, idx) => {
          formRv.append(key, currentDomain[key]);
        });
        var result = await axiosClient.put(
          `/api/identity/domain/${currentDomain.id}`,
          currentDomain
        );
        console.log(result);
        if(result.status === 200){
          setIsReload(true);
        }
        break;
      default:
        break;
    }
    setAction("");
  };
  const statusTemplate = (col) => {
    return col === DOMAINSTATUS.NEW ? (
      <TagComponent
        name={col}
        isFull={true}
        type={TagType.INFOR}
      ></TagComponent>
    ) : col === DOMAINSTATUS.APPROVED ? (
      <TagComponent
        name={col}
        isFull={true}
        type={TagType.SUCCESS}
      ></TagComponent>
    ) : col === DOMAINSTATUS.REVIEW ? (
      <TagComponent
        name={col}
        isFull={true}
        type={TagType.WARNING}
      ></TagComponent>
    ) : (
      <TagComponent
        name={col}
        isFull={true}
        type={TagType.DANGER}
      ></TagComponent>
    );
  };
  const toggleComponent = (i) => {
    if (currentDomain.domainComponents.findIndex((x) => x.id === i.id) !== -1) {
      setCurrentDomain({
        ...currentDomain,
        domainComponents: [
          ...currentDomain.domainComponents.filter((x) => x.id !== i.id),
        ],
      });
    } else {
      setCurrentDomain({
        ...currentDomain,
        domainComponents: [...currentDomain.domainComponents, i],
      });
    }
  };
  const renderAdminButton = (domain) => {
    if (domain.domainStatus === DOMAINSTATUS.NEW) {
      return (
        <div className="align-center">
          <Link
            to={"#"}
            onClick={() => {
              setAction(ACTION.CONFIRMREVIEW);
              setCurrentDomain(domain);
            }}
            className="btn btn-primary"
          >
            <ion-icon name="hourglass-outline" size="large"></ion-icon>
          </Link>
        </div>
      );
    }
    if (domain.domainStatus === DOMAINSTATUS.REVIEW) {
      return (
        <div className="align-center">
          <Link
            to={"#"}
            onClick={() => {
              setAction(ACTION.CONFIRMDECLINED);
              setCurrentDomain(domain);
            }}
            className="btn btn-danger"
          >
            <ion-icon name="thumbs-down-outline" size="large"></ion-icon>
          </Link>
          <Link
            to={"#"}
            onClick={() => {
              setAction(ACTION.CONFIRMAPPROVED);
              setCurrentDomain(domain);
            }}
            className="btn btn-success"
          >
            <ion-icon name="checkmark-done-outline" size="large"></ion-icon>
          </Link>
        </div>
      );
    }
  };
  return (
    <div className="domain-manage-page">
      {domainData.length > 0 && (
        <DataTableComponent
          rows={domains}
          headers={[
            "Tên trường",
            "Viết tắt",
            "Trạng thái",
            "Email liên hệ",
            "Website",
            "Logo",
            "Quản lý",
          ]}
          headerTitle={"Quản lý Domain"}
          columnsTemplate={[
            {
              key: "status",
              template: statusTemplate,
            },
          ]}
          customizeColumns={[
            {
              header: "Duyệt",
              body: renderAdminButton,
            },
          ]}
          idColumn="id"
          imageColumns={["image", "schoolLogoPath"]}
          hideColumns={["components", "id", "domainAdminId", "isActive"]}
          isAddable={true}
          isDeleteable={true}
          isEditable={true}
          isImportable={true}
          openAddModal={() => setAction(ACTION.CREATE)}
          openEditModal={(e) => {
            setAction(ACTION.EDIT);
            setCurrentDomain(e);
          }}
          openDeleteModal={(e) => {
            setAction(ACTION.DELETE);
            setCurrentDomain(e);
          }}
          openImportModal={() => {
            setAction(ACTION.IMPORT);
          }}
          fetch={true}
        ></DataTableComponent>
      )}
      <ModalTransition>
        {isOpen && (
          <Modal onClose={toggleModal}>
            <ModalHeader>
              <ModalTitle>{action === ACTION.CREATE}</ModalTitle>
            </ModalHeader>
            <ModalBody>
              <div>
                <form className="form">
                  {action === ACTION.CREATE && (
                    <>
                      <div className="form-group">
                        <label>Tên trường (*)</label>
                        <input
                          onChange={(e) => createValueChange(e)}
                          name="schoolName"
                          className="form-field"
                          placeholder="VD: Trường tiểu học ABC"
                        />
                      </div>
                      <div className="form-group">
                        <label>
                          Tên viết tắt (*) <i>Lưu ý: viết liền không dấu</i>
                        </label>
                        <input
                          onChange={(e) => createValueChange(e)}
                          name="abbreviation"
                          className="form-field"
                          placeholder="VD: ABCSCHOOL"
                        />
                      </div>
                      <div className="form-group">
                        <label>Địa chỉ trường (*)</label>
                        <input
                          onChange={(e) => createValueChange(e)}
                          name="address"
                          className="form-field"
                          placeholder="VD: Số 1 ABC, DEF"
                        />
                      </div>
                      <div className="form-group">
                        <label>Logo trường (*)</label>
                        <input
                          onChange={(e) => createValueChange(e, true)}
                          name="file"
                          className="form-field"
                          type="file"
                        />
                      </div>
                      <div className="form-group">
                        <label>Email trường (*)</label>
                        <input
                          onChange={(e) => createValueChange(e)}
                          name="schoolEmail"
                          className="form-field"
                        />
                      </div>
                    </>
                  )}
                  {action === ACTION.EDIT && (
                    <>
                      <div className="form-group">
                        <label>Tên trường</label>
                        <input
                          onChange={(e) => editValueChange(e)}
                          name="schoolName"
                          className="form-field"
                          defaultValue={currentDomain.schoolName}
                        />
                      </div>
                      <div className="form-group">
                        <label>Viết tắt</label>
                        <input
                          onChange={(e) => editValueChange(e)}
                          name="abbreviation"
                          className="form-field"
                          defaultValue={currentDomain.abbreviation}
                        />
                      </div>
                      <div className="form-group">
                        <label>Trạng thái</label>
                        <select
                          onChange={(e) => editValueChange(e)}
                          name="status"
                          className="form-field"
                          defaultValue={currentDomain.status}
                        >
                          {Object.keys(DOMAINSTATUS).map((key, idx) => (
                            <option key={idx} value={DOMAINSTATUS[key]}>
                              {DOMAINSTATUS[key]}
                            </option>
                          ))}
                        </select>
                      </div>
                      <div className="form-group">
                        <label>Email liên hệ</label>
                        <input
                          onChange={(e) => editValueChange(e)}
                          name="schoolEmail"
                          className="form-field"
                          defaultValue={currentDomain.schoolEmail}
                        />
                      </div>
                      <div className="form-group">
                        <label>Components</label>
                        <CheckListComponent
                          displayName={"componentName"}
                          item={availableComponent}
                          own={currentDomain.components}
                          click={(i) => toggleComponent(i)}
                        ></CheckListComponent>
                      </div>
                    </>
                  )}
                  {action === ACTION.DELETE && (
                    <div>
                      <h2 className="text-info">
                        Bạn có chắc chắn xóa domain này
                      </h2>
                      <h3>Không thể hoàn tác</h3>
                    </div>
                  )}
                  {action === ACTION.IMPORT && (
                    <>
                      <h3>Import file</h3>
                      <div className="form-group">
                        <label>Chọn file excel</label>
                        <input
                          type="file"
                          name="file"
                          className="form-field"
                          onChange={(e) => createValueChange(e, true)}
                        />
                      </div>
                    </>
                  )}
                  {(action === ACTION.CONFIRMREVIEW ||
                    action === ACTION.CONFIRMDECLINED ||
                    action === ACTION.CONFIRMAPPROVED) && (
                    <div>
                      Bạn có chắc muốn chuyển trạng thái của domain thành{" "}
                      {action}?
                    </div>
                  )}
                </form>
              </div>
            </ModalBody>
            <ModalFooter>
              <button onClick={submit}>Lưu</button>
            </ModalFooter>
          </Modal>
        )}
      </ModalTransition>
    </div>
  );
};

export default DomainManagePage;
