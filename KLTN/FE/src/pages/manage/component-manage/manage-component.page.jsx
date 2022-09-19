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
import "./manage-component.css";
import axiosClient from "../../../global/axios/axiosClient";
const componentData = [
  {
    id: 'a5664ae0-d938-4cee-9267-4309aba108ad',
    componentName: "test",
    componentEndpoint: "/test",
    componentLogo: "airplane-outline",
    price: 0,
  },
  {
    id:'b5664ae0-d938-4cee-9267-4309aba108ad',
    componentName: "test",
    componentEndpoint: "/test",
    componentLogo: "airplane-outline",
    price: 0,
  },
  {
    id: 'c664ae0-d938-4cee-9267-4309aba108ad',
    componentName: "test",
    componentEndpoint: "/test",
    componentLogo: "airplane-outline",
    price: 0,
  },
];
const ComponentManagePage = () => {
  const [action, setAction] = useState("");
  const [component, setComponent] = useState({});
  const [isOpen, setIsOpen] = useState(false);
  const [currentComponent, setCurrentComponent] = useState({});
  useEffect(() => {
    if (action !== "") {
      setIsOpen(true);
    }
  }, [action, setAction]);

  const toggleModal = () => {
    if (action !== "" && isOpen) {
      setAction("");
    }
    setIsOpen(!isOpen);
  };
  const submit = async () => {
    switch (action) {
      case ACTION.CREATE:
        console.log(component);
        var result = await axiosClient.post("/api/identity/component",component);
        console.log(result);
        break;
      case ACTION.EDIT:
        console.log(currentComponent);
        const resultedit = await axiosClient.put(`/api/identity/component/${currentComponent.id}`,currentComponent);
        console.log(resultedit);
        break;
      case ACTION.DELETE:
        console.log(currentComponent);
        const resultDelete = await axiosClient.delete(`/api/identity/component/${currentComponent.id}`);
        console.log(resultDelete);
        break;
      default:
        break;
    }
  };
  const valueChange = (e) => {
    setComponent({
      ...component,
      [e.target.name]: e.target.value,
    });
  };
  const editValueChange = (e) => {
    setCurrentComponent({
      ...currentComponent,
      [e.target.name]: e.target.value,
    });
  };
  useEffect(() => {
    const fetchData = async () => {
      var result = await axiosClient.get("/api/identity/component");
      console.log(result);
    };
    fetchData();
  }, []);
  return (
    <div className="component-manage-page">
      <DataTableComponent
        rows={componentData}
        headers={["Tên module", "Module endpoint", "Module logo", "Giá module"]}
        headerTitle={"Quản lý Module"}
        idColumn="id"
        hideColumns={["id"]}
        isAddable={true}
        isDeleteable={true}
        isEditable={true}
        openAddModal={() => setAction(ACTION.CREATE)}
        openEditModal={(e) => {
          setAction(ACTION.EDIT);
          setCurrentComponent(e);
        }}
        openDeleteModal={(e) => {
          setAction(ACTION.DELETE);
          setCurrentComponent(e);
        }}
      ></DataTableComponent>
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
                        <label>Tên component</label>
                        <input
                          onChange={(e) => valueChange(e)}
                          className="form-field"
                          name="componentName"
                        />
                      </div>
                      <div className="form-group">
                        <label>Component endpoint</label>
                        <input
                          onChange={(e) => valueChange(e)}
                          className="form-field"
                          name="componentEndpoint"
                        />
                      </div>
                      <div className="form-group">
                        <label>Component Logo</label>
                        <input
                          onChange={(e) => valueChange(e)}
                          className="form-field"
                          name="componentLogo"
                        />
                      </div>
                    </>
                  )}
                  {action === ACTION.EDIT && (
                    <>
                      <div className="form-group">
                        <label>Tên component</label>
                        <input
                          defaultValue={currentComponent.componentName}
                          onChange={(e) => editValueChange(e)}
                          className="form-field"
                          name="componentName"
                        />
                      </div>
                      <div className="form-group">
                        <label>Component endpoint</label>
                        <input
                          defaultValue={currentComponent.componentEndpoint}
                          onChange={(e) => editValueChange(e)}
                          className="form-field"
                          name="componentEndpoint"
                        />
                      </div>
                      <div className="form-group">
                        <label>Component Logo</label>
                        <div>
                          {currentComponent.componentLogo && (
                            <ion-icon
                              size="large"
                              name={currentComponent.componentLogo}
                            ></ion-icon>
                          )}
                        </div>
                        <input
                          defaultValue={currentComponent.componentLogo}
                          onChange={(e) => editValueChange(e)}
                          className="form-field"
                          name="componentLogo"
                        />
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
                </form>
              </div>
            </ModalBody>
            <ModalFooter>
            </ModalFooter>
          </Modal>
        )}
      </ModalTransition>
    </div>
  );
};
export default ComponentManagePage;
