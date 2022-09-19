import { useEffect, useRef, useState } from "react";
import "./tree.css";
import { MenuItem, useMenuState, ControlledMenu } from "@szhsin/react-menu";
import "@szhsin/react-menu/dist/core.css";
import "@szhsin/react-menu/dist/index.css";
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";
import { ACTION } from "../../consts/action.const";
import axiosClient from "../../global/axios/axiosClient";

function TreeComponent({
  rootNode,
  isShowAll,
  rootTemplate,
  selectNode,
  isModifiable,
  refresh,
  id,
  currentNode,
  isChild = false,
}) {
  const childrenRef = useRef();
  const [isExpand, setIsExpand] = useState(false);
  const select = () => {
    childrenRef.current.classList.toggle("collapsed");
    setIsExpand(!isExpand);
  };
  const [isAvail, setIsAvail] = useState(true);
  const setIsAvailable = () => {
    setIsAvail(true);
  };
  const nodeClick = (node) => {
    selectNode(node);
    setCurrrent(node);
    if (isChild) {
      setIsAvail(false);
    }
    console.log(node);
  };
  const [current, setCurrrent] = useState(null);
  const [menuProps, toggleMenu] = useMenuState();
  const [anchorPoint, setAnchorPoint] = useState({ x: 0, y: 0 });
  const [isOpen, setIsOpen] = useState(false);
  const [action, setAction] = useState("");
  const [currentSection, setCurrentSection] = useState(null);

  const toggleModal = (action) => {
    setIsOpen(!isOpen);
    setAction(action);
  };
  // useEffect(() => {
  //   document.addEventListener("contextmenu", (event) => {
  //     event.preventDefault();
  //   });
  // }, []);
  const [addSection, setAddSection] = useState({});
  const valueChange = (e) => {
    setAddSection({
      ...addSection,
      [e.target.name]: e.target.value,
    });
  };
  const updateValueChange = (e) => {
    setCurrentSection({
      ...currentSection,
      [e.target.name]: e.target.value,
    });
  };
  const [contextCurrent, setContextCurrent] = useState(null);
  const submit = async () => {
    switch (action) {
      case ACTION.ADDSECTION:
        console.log(addSection);
        const addData = {
          action: 1,
          ...addSection,
          teacherSubjectId: id,
          rootId: contextCurrent ? contextCurrent.id : null,
        };
        const addResult = await axiosClient.post(
          "api/course/sections",
          addData
        );
        console.log(addResult);
        break;
      case ACTION.EDITSECTION:
        console.log(contextCurrent);
        const updateData = {
          action: 2,
          ...contextCurrent,
        };
        const updateResult = await axiosClient.post(
          "api/course/sections",
          updateData
        );
        console.log(updateResult);
        break;
      case ACTION.DELETESECTION:
        console.log(contextCurrent);
        const deleteData = {
          action: 3,
          ...contextCurrent,
        };
        const deleteResult = await axiosClient.post(
          "api/course/sections",
          deleteData
        );
        console.log(deleteResult);
        break;
      default:
        break;
    }
    setIsOpen(false);
    if (refresh) {
      refresh();
    }
  };
  return (
    <div className="tree_component">
      <div className="tree">
        <ul className="tree-ul">
          <li className="item">
            <button
              className="node"
              onContextMenu={(e) => {
                if (isModifiable) {
                  e.preventDefault();
                  setAnchorPoint({ x: e.clientX, y: e.clientY });
                  toggleMenu(true);
                  if (rootNode.id !== 'root') {
                    setContextCurrent(rootNode);
                  }
                }
              }}
              onClick={select}
              key={rootNode.id}
            >
              <ion-icon
                size="large"
                name={`${!isExpand ? "folder-open" : "folder"}-outline`}
              ></ion-icon>{" "}
              {rootNode.title}
            </button>
            <ul
              ref={childrenRef}
              className={`tree-ul children ${!isShowAll ? "collapsed" : ""}`}
            >
              {rootNode.children.map((child, idx) => {
                if (child.children.length > 0) {
                  return (
                    <TreeComponent
                      isModifiable={isModifiable}
                      selectNode={selectNode}
                      isShowAll={isShowAll}
                      rootNode={child}
                      isAvailable={isAvail}
                      setAvailable={setIsAvailable}
                      isChild={true}
                      id={id}
                      currentNode={currentNode}
                      key={idx}
                    ></TreeComponent>
                  );
                } else {
                  return (
                    <li
                      onContextMenu={(e) => {
                        if (isModifiable) {
                          e.preventDefault();
                          setAnchorPoint({ x: e.clientX, y: e.clientY });
                          toggleMenu(true);
                          setCurrentSection(child);
                          setContextCurrent(child);
                        }
                      }}
                      className={`item ${child.id === currentNode?.id && "current"}`}
                      onClick={() => nodeClick(child)}
                      key={idx}
                    >
                      <button>{child.title}</button>
                    </li>
                  );
                }
              })}
            </ul>
          </li>
        </ul>
      </div>


      <ModalTransition>
        {isOpen && (
          <Modal
            onClose={toggleModal}
            width={"large"}
            css={{ width: "100%", height: "100%" }}
          >
            <ModalHeader appearance="info">
              <ModalTitle>
                {action === ACTION.ADDSECTION && <h4>Thêm chương</h4>}
                {action === ACTION.EDITSECTION && <h4>Cập nhật chương</h4>}
                {action === ACTION.DELETESECTION && <h4>Xóa chương</h4>}
              </ModalTitle>
            </ModalHeader>
            <ModalBody>
              <form action="">
                {action === ACTION.ADDSECTION && (
                  <>
                    <div className="form-group">
                      <label>Tiêu đề</label>
                      <input
                        onChange={(e) => valueChange(e)}
                        type="text"
                        className="form-field"
                        name="title"
                      />
                    </div>
                    <div className="form-group">
                      <label>Ngày bắt đầu</label>
                      <input
                        type="date"
                        className="form-field"
                        name="fromDate"
                        onChange={(e) => valueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label>Ngày kết thúc</label>
                      <input
                        onChange={(e) => valueChange(e)}
                        type="date"
                        className="form-field"
                        name="toDate"
                      />
                    </div>
                  </>
                )}
                {action === ACTION.EDITSECTION && (
                  <>
                    <div className="form-group">
                      <label>Tiêu đề</label>
                      <input
                        type="text"
                        className="form-field"
                        name="title"
                        defaultValue={currentSection.title}
                        onChange={(e) => updateValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label>Ngày bắt đầu</label>
                      <input
                        type="date"
                        className="form-field"
                        name="fromDate"
                        defaultValue={currentSection.fromDate}
                        onChange={(e) => updateValueChange(e)}
                      />
                    </div>
                    <div className="form-group">
                      <label>Ngày kết thúc</label>
                      <input
                        type="date"
                        className="form-field"
                        name="toDate"
                        defaultValue={currentSection.toDate}
                        onChange={(e) => updateValueChange(e)}
                      />
                    </div>
                  </>
                )}
                {action === ACTION.DELETESECTION && (
                  <>
                    Bạn có chắc chắn xóa chương này không, mọi thông tin liên
                    quan sẽ mất?
                  </>
                )}
              </form>
            </ModalBody>
            <ModalFooter>
              <button
                onClick={() => toggleModal("")}
                className="noselect secondary text-center"
              >
                <span className="text">Hủy</span>
                <span className="icon">
                  <ion-icon size="large" name="close-outline"></ion-icon>
                </span>
              </button>
              <button
                onClick={() => submit()}
                className="noselect primary text-center"
              >
                <span className="text">Lưu</span>
                <span className="icon">
                  <ion-icon size="large" name="save-outline"></ion-icon>
                </span>
              </button>
            </ModalFooter>
          </Modal>
        )}
      </ModalTransition>
      <ControlledMenu
        {...menuProps}
        anchorPoint={anchorPoint}
        onClose={() => toggleMenu(false)}
      >
        <MenuItem onClick={() => toggleModal(ACTION.ADDSECTION)}>
          Thêm chương
        </MenuItem>
        <MenuItem onClick={() => toggleModal(ACTION.EDITSECTION)}>
          Cập nhật
        </MenuItem>
        <MenuItem onClick={() => toggleModal(ACTION.DELETESECTION)}>
          Xóa
        </MenuItem>
      </ControlledMenu>
    </div>
  );
}

export default TreeComponent;
