import { useEffect, useRef, useState } from "react";
import { useLocation } from "react-router-dom";
import { useHistory } from "react-router-dom";
import { Link, Router } from "react-router-dom";
import { HiOutlineDatabase } from "react-icons/hi";
import { MdOutlineManageAccounts } from "react-icons/md";
import "./menu.css";
import { useSelector } from "react-redux";
import { ROLE } from "../../consts/role.const";
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";
const MenuPage = ({ MySwal }) => {
  const { location } = useHistory();
  const history = useHistory();
  const [isSearchFocused, setIsSearchFocused] = useState(false);
  const [isOtherOpen, setIsOtherOpen] = useState(false);
  const otherMenuRef = useRef();
  const ignoreClickOnMeElement = document.getElementById("app");
  const toggleModal = () => {
    setIsOtherOpen(!isOtherOpen);
  };
  const { account, isRefresh } = useSelector((x) => x.auth);
  console.log(account);
  console.log(isRefresh);
  return (
    <>
      <div className="search-box">
        <input
          onFocus={() => setIsSearchFocused(true)}
          onBlur={() => setIsSearchFocused(false)}
          className="search-input"
          type="text"
        />
        <span className={isSearchFocused ? "d-none" : ""}>
          <ion-icon name="search-outline"></ion-icon>
          <div>Search</div>
        </span>
      </div>
      <div
        className="menu-page"
        onClick={() => {
          if (isOtherOpen) {
            setIsOtherOpen(false);
          }
        }}
      >
        <div className="menu">
          {account &&
            (account.role === ROLE.STUDENT ||
              account.role === ROLE.TEACHER) && (
              <div className="component">
                <Link to={`${location.pathname}/ticket`}>
                  <span>
                    <ion-icon className="icon" name="ticket-outline"></ion-icon>
                  </span>
                </Link>
                <h4>PYC</h4>
              </div>
            )}
          {account && account?.role === ROLE.STUDENT && (
            <div className="component">
              <Link to={`${location.pathname}/jira`}>
                <span>
                  <ion-icon
                    className="icon"
                    name="clipboard-outline"
                  ></ion-icon>
                </span>
              </Link>
              <h4>Jira board</h4>
            </div>
          )}
          {account &&
            (account.role === ROLE.STUDENT ||
              account.role === ROLE.TEACHER) && (
              <div className="component">
                <Link to={`${location.pathname}/meeting`}>
                  <span>
                    <ion-icon
                      className="icon"
                      name="archive-outline"
                    ></ion-icon>
                  </span>
                </Link>
                <h4>Meeting</h4>
              </div>
            )}
          {account &&
            (account.role === ROLE.STUDENT ||
              account.role === ROLE.TEACHER) && (
              <div className="component">
                <Link to={`${location.pathname}/chat`}>
                  <span>
                    <ion-icon
                      className="icon"
                      name="chatbubble-outline"
                    ></ion-icon>
                  </span>
                </Link>
                <h4>Chat</h4>
              </div>
            )}
          {account && account.role === ROLE.SCHOOL_ADMIN && (
            <div className="component">
              <Link to={`${location.pathname}/domain`}>
                <span>
                  <ion-icon name="file-tray-full-outline"></ion-icon>
                </span>
              </Link>
              <h4>Domain</h4>
            </div>
          )}
          {account?.role !== ROLE.STUDENT && account?.role !== ROLE.PARENT && (
            <div className="component">
              <Link to={`${location.pathname}/attendance`}>
                <span>
                  <ion-icon className="icon" name="checkbox-outline"></ion-icon>
                </span>
              </Link>
              <h4>Attendance</h4>
            </div>
          )}
          {account?.role === ROLE.TEACHER && (
            <div className="component">
              <Link to={`${location.pathname}/exam`}>
                <span>
                  <ion-icon className="icon" name="clipboard-outline"></ion-icon>
                </span>
              </Link>
              <h4>Exam</h4>
            </div>
          )}
          {account?.role === ROLE.TEACHER && (
            <div className="component">
              <Link to={`${location.pathname}/manage-question`}>
                <span>
                  <HiOutlineDatabase className="icon"></HiOutlineDatabase>
                </span>
              </Link>
              <h4>Question</h4>
            </div>
          )}
          {account && account?.role === ROLE.DOMAIN_ADMIN && (
            <div className="component">
              <Link to={`${location.pathname}/manage-component`}>
                <span>
                  <ion-icon
                    className="icon"
                    name="logo-web-component"
                  ></ion-icon>
                </span>
              </Link>
              <h4>Component</h4>
            </div>
          )}
          {account && account.role === ROLE.STUDENT && (
            <div className="component">
              <Link to={`${location.pathname}/log-work`}>
                <span>
                  <ion-icon className="icon" name="bicycle-outline"></ion-icon>
                </span>
              </Link>
              <h4>Log work</h4>
            </div>
          )}
          {/* {account?.role !== ROLE.STUDENT && account?.role !== ROLE.PARENT && (
            <div className="component">
              <Link to={`${location.pathname}`} onClick={toggleModal}>
                <span>
                  <MdOutlineManageAccounts className="icon"></MdOutlineManageAccounts>
                </span>
              </Link>
              <h4>Manage</h4>
            </div>
          )} */}
        </div>
        <ModalTransition>
          {isOtherOpen && (
            <Modal onClose={toggleModal}>
              <ModalBody>
                <div className="other-menu" ref={otherMenuRef}>
                  <div className="component">
                    <Link to={`${location.pathname}/manage-subject`}>
                      <span>
                        <ion-icon name="terminal-outline"></ion-icon>
                      </span>
                      <h4>Subject</h4>
                    </Link>
                  </div>
                  <div className="component">
                    <Link to={`${location.pathname}/manage-question`}>
                      <span>
                        <HiOutlineDatabase className="icon"></HiOutlineDatabase>
                      </span>
                      <h4>Question</h4>
                    </Link>
                  </div>
                  <div className="component">
                    <Link to={`${location.pathname}/manage-task`}>
                      <span>
                        <ion-icon name="clipboard-outline"></ion-icon>
                      </span>
                      <h4>Task</h4>
                    </Link>
                  </div>
                  <div className="component">
                    <Link to={`${location.pathname}/manage-ticket`}>
                      <span>
                        <ion-icon name="ticket-outline"></ion-icon>
                      </span>
                      <h4>Ticket</h4>
                    </Link>
                  </div>
                  <div className="component">
                    <Link to={`${location.pathname}/manage-domain`}>
                      <span>
                        <ion-icon name="business-outline"></ion-icon>
                      </span>
                      <h4>Domain</h4>
                    </Link>
                  </div>
                  <div className="component">
                    <Link to={`${location.pathname}/manage-hr`}>
                      <span>
                        <ion-icon name="people-outline"></ion-icon>
                      </span>
                      <h4>HR</h4>
                    </Link>
                  </div>
                  <div className="component">
                    <Link to={`${location.pathname}/manage-component`}>
                      <span>
                        <ion-icon name="logo-web-component"></ion-icon>
                      </span>
                      <h4>Component</h4>
                    </Link>
                  </div>
                </div>
              </ModalBody>
            </Modal>
          )}
        </ModalTransition>
      </div>
    </>
  );
};

export default MenuPage;
