import { useEffect, useRef, useState } from "react";
import { Route, Switch, useRouteMatch } from "react-router-dom";
import { useHistory } from "react-router-dom";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { Link } from "react-router-dom";
import { ROLE } from "../../consts/role.const";
import ChatPage from "../../pages/chat/chat.page";
import HomePage from "../../pages/home/home.page";
import LearnDetailPage from "../../pages/learn/learn-detail/learn-detail.page";
import LearnPage from "../../pages/learn/learn.page";
import OnlineMeetingPage from "../../pages/online-meeting/online-meeting.page";
import SchedulePage from "../../pages/schedule/schedule.page";
import FooterComponent from "../footer/footer.component";
import LoadingComponent from "../loading/loading.component";
import BreadcrumbComponent from "../breadcumb/breadcrumb.component";
import TicketPage from "../../pages/ticket/ticket.page";
import JiraPage from "../../pages/jira/jira.page";
import MenuPage from "../../pages/menu/menu.page";
import AttendancePage from "../../pages/attendance/attendance.page";
import SubjectManagePage from "../../pages/manage/subject-manage/subject-manage.page";
import LogworkPage from "../../pages/logwork/logwork.page";
import ExamPage from "../../pages/learn/exam/exam.page";
import LearnDashboardPage from "../../pages/learn/learn-dashboard/learn-dashboard.page";
import QuestionManagePage from "../../pages/manage/question-manage/question-manage.page";
import DomainManagePage from "../../pages/manage/domain-manage/domain-manage.page";
import ClassManagePage from "../../pages/manage/class-manage/class-manage.page";
import ClassManageDetailPage from "../../pages/manage/class-manage/class-manage-detail/class-manage-detail.page";
import SubjectManageDetailPage from "../../pages/manage/subject-manage/subject-manage-detail/subject-manage-detail.page";
import TicketManagePage from "../../pages/manage/ticket-manage/ticket-manage.page";
import HRManagePage from "../../pages/manage/hr-manage/hr-manage.page";
import TaskManagePage from "../../pages/manage/task-manage/task-manage.page";
import DoExamPage from "../../pages/learn/do-exam/do-exam.page";
import { useDispatch, useSelector } from "react-redux";
import {
  persist,
  refresh,
  refreshNavigation,
  signOut,
} from "../../redux/actions/Auth/auth.action";
import ComponentManagePage from "../../pages/manage/component-manage/manage-component.page";
import { ToastContainer } from "react-toastify";
import SelfDomainManage from "../../pages/manage/domain-manage/self-domain-manage.page";
import LobbyPage from "../../pages/online-meeting/lobby.page";
import messageConnection from "../../services/message.service";
import { HubConnectionState } from "@microsoft/signalr";
import { useJwt } from "react-jwt";
import TaskReportPage from "../../pages/report/task-report.page";
import TicketReportPage from "../../pages/ticket/ticket-report.page";
import ProjectReportPage from "../../pages/report/project-report.page";
import ReportHomePage from "../../pages/report/report-home.page";
import ClassReportPage from "../../pages/report/class-report.page";
import axios from "axios";
import axiosClient from "../../global/axios/axiosClient";
import SettingPage from "../../pages/setting/setting.page";
import connection from "../../services/signalr.service";
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";
const WrapperComponent = ({ component }) => {
  const history = useHistory();
  const { isExpired } = useJwt(localStorage.getItem("token"));
  const { account, navigationRefresh, expiredIn } = useSelector(
    (state) => state.auth
  );
  const { auth } = useSelector((x) => x.auth);
  const dispatch = useDispatch();
  // useEffect(() => {
  //   console.log(isExpired);
  //   if (isExpired) {
  //     dispatch(signOut())
  //     history.push("/auth");
  //   }
  // }, [isExpired]);
  const [notification, setNotification] = useState([]);
  const [messages, setMessages] = useState([]);
  const MySwal = withReactContent(Swal);
  const navItemRef = useRef();
  const sideNavRef = useRef();
  const mainRef = useRef();
  const { location } = useHistory();

  const [isLoading, setIsLoading] = useState(true);
  const footerRef = useRef();
  const [menuPosition, setMenuPosition] = useState({
    x: 23,
    y: 5,
  });
  let { url, path } = useRouteMatch();
  useEffect(() => {
    if (account.role === ROLE.SCHOOL_ADMIN) {
      history.push(`${path}/menu/domain`)
    }
  }, [])
  useEffect(() => {
    navItemRef.current.childNodes?.forEach((child, idx) => {
      if (idx !== 0) {
        child.addEventListener("click", () => {
          navItemRef.current.childNodes?.forEach((t, i) => {
            if (i !== 0) {
              t.classList.remove("active");
            }
          });
          child.classList.add("active");
          setIsLoading(true);
        });

        const url = new URL(child.firstChild.href);
        const pathname = url.pathname; // contains "/register"

        var currPathSeg = pathname.split("/");
        var linkPathSeg = location.pathname.split("/");

        child.classList.remove("active");
        if (currPathSeg.length === 2) {
          if (pathname === location.pathname) {
            child.classList.add("active");
          }
        } else {
          let flag = true;
          currPathSeg.forEach((seg, idx) => {
            if (seg !== linkPathSeg[idx]) {
              flag = false;
            }
          });
          if (flag) {
            child.classList.add("active");
          }
        }
      }
    });
    MySwal.close();
  }, [location.pathname]);

  const toggleMenu = () => {
    if (sideNavRef.current.classList.contains("full")) {
      sideNavRef.current.classList.remove("full");
      mainRef.current.classList.remove("full");
    } else {
      sideNavRef.current.classList.toggle("collapsed");
      mainRef.current.classList.toggle("collapsed");
    }
  };
  function allowDrop(ev) {
    ev.preventDefault();
  }
  function onDrop(ev) {
    console.log(ev.view.innerHeight, ev.pageY);
    console.log(ev.view.innerWidth, ev.pageX);
    if (
      ev.pageX < ev.view.innerWidth - 35 &&
      ev.pageX > 0 &&
      ev.pageY < ev.view.innerHeight &&
      ev.pageY > 0
    ) {
      setMenuPosition({ ...menuPosition, x: ev.pageX - 20, y: ev.pageY - 20 });
    }
  }
  const displayDropdown = (e) => {
    const user = document.getElementById(`user-dropdown`);
    const message = document.getElementById(`message-dropdown`);
    const noti = document.getElementById(`notification-dropdown`);
    user.classList.add("hidden");
    message.classList.add("hidden");
    noti.classList.add("hidden");
    const dropdown = document.getElementsByClassName(`${e}-drop-down`);

    dropdown[0].classList.toggle("hidden");
    document.addEventListener("click", (event) => {
      const target = event.target;
      if (
        !target.classList.contains(`${e}-drop-down`) &&
        target.tagName !== "ION-ICON"
      ) {
        if (dropdown[0] && !dropdown[0].classList.contains("hidden")) {
          dropdown[0].classList.add("hidden");
        }
      }
    });
  };
  const logout = () => {
    dispatch(signOut());
    history.push("/auth");
  };
  const [isReceivedCall, setIsReceivedCall] = useState(false);
  const [receivedCallDetail, setReceivedCallDetail] = useState(null);
  useEffect(() => {
    // if(account == null){
    //   history.push("/auth/unauthorized");
    // }
    if (account.id) {
      console.log(account);
      const startConnect = async () => {
        if (messageConnection.state === HubConnectionState.Disconnected) {
          await messageConnection.start();
          const connectData = {
            accountId: account.id,
            domainId: account.domain.id,
            username: account.username,
            fullname: account.username,
          };
          messageConnection.send("ChatConnect", connectData);
        }
      };
      startConnect();
      messageConnection.on("refresh", () => {
        console.log("refresh event from server");
        dispatch(refresh());
      });
      messageConnection.on("navigationrefresh", () => {
        dispatch(refreshNavigation());
      });
      messageConnection.on("calling", (data) => {
        console.log("teacher start online class");
        setReceivedCallDetail(data);
        setIsReceivedCall(true);
      })
    }
  }, [account]);
  useEffect(() => {
    console.log("cnn", account);
    const fetch = async () => {
      if (account) {
        const conversations = await axiosClient.get(
          `/api/crm/conversations/realtime?accountId=${account.id}`
        );
        const notification = await axiosClient.get(
          `/api/crm/notification?accountId=${account.id}`
        );
        setNotification(notification);
        setMessages(conversations);
      }
    };
    if (account.id) {
      fetch();
    }
  }, [navigationRefresh, account]);
  const seenNotify = async (notify) => {
    var result = await axiosClient.put(
      `/api/crm/notification/${notify.id}?accountId=${account.id}`
    );
    if (result.status === 200) {
      console.log("thành công");
    }
  };
  return (
    <div className="wrapper-container">
      <div className="wrapper">
        <ModalTransition>
          {isReceivedCall && <Modal css={{ width: "100%", height: "100%" }} >
            <ModalHeader>
              Buổi học online đã bắt đầu
            </ModalHeader>
            <ModalBody>
              <h3>GV {receivedCallDetail.teacherFullname} đã bắt đầu buổi học online</h3>
              <h4>Môn: {receivedCallDetail.subjectName}</h4>
              <h5>Thời lượng: {receivedCallDetail.duration} giờ</h5>
              <Link onClick={() => setIsReceivedCall(false)} to={`${path}/meeting/${receivedCallDetail.meetingId}`}>Tham gia ngay</Link>
            </ModalBody>
          </Modal>}
        </ModalTransition>
        <div className="side-navigation collapsed full" ref={sideNavRef}>
          <ul ref={navItemRef}>
            <li className="school-logo">
              <Link to={`${url}`}>
                <span className="icon">
                  {account?.domain?.schoolLogoPath ? (
                    <img alt="logo" src="/img/school-logo.png" />
                  ) : (
                    <ion-icon size="large" name="paw-outline"></ion-icon>
                  )}
                </span>
                <span className="title">LMS</span>
              </Link>
            </li>
            {account &&
              (account.role === ROLE.STUDENT ||
                account.role === ROLE.TEACHER) && (
                <li>
                  <Link to={`${url}/learn`}>
                    <span className="icon">
                      <ion-icon size="large" name="help-outline"></ion-icon>
                    </span>
                    <span className="title">Learn</span>
                  </Link>
                </li>
              )}
            <li>
              <Link to={`${url}`}>
                <span className="icon">
                  <ion-icon size="large" name="home-outline"></ion-icon>
                </span>
                <span className="title">Home</span>
              </Link>
            </li>
            <li>
              <Link to={`${url}/menu`}>
                <span className="icon">
                  <ion-icon size="large" name="grid-outline"></ion-icon>
                </span>
                <span className="title">Menu detail</span>
              </Link>
            </li>

            <li>
              <Link to={`${url}/setting`}>
                <span className="icon">
                  <ion-icon size="large" name="settings-outline"></ion-icon>
                </span>
                <span className="title">Settings</span>
              </Link>
            </li>
            <li>
              <Link to={"/# "} onClick={logout}>
                <span className="icon">
                  <ion-icon size="large" name="log-out-outline"></ion-icon>
                </span>
                <span className="title">Sign out</span>
              </Link>
            </li>
          </ul>
        </div>

        {/* main */}
        <div className="main collapsed full" ref={mainRef}>
          <div className="topbar">
            <div className="toggle" onClick={toggleMenu}>
              <ion-icon size="large" name="menu-outline"></ion-icon>
            </div>
            {/* search */}
            <div className="search">
              <label htmlFor="">
                <input type="text" name="" id="" placeholder="search here" />
                <ion-icon name="search-outline"></ion-icon>
              </label>
            </div>
            <div className="info">
              <div className="notify">
                <ion-icon
                  onClick={() => displayDropdown("notify")}
                  size="large"
                  name="notifications-outline"
                ></ion-icon>
                {notification.length > 0 && (
                  <span className="mini">
                    {notification.length > 100 ? "n" : notification.length}
                  </span>
                )}
              </div>
              <div className="message">
                <ion-icon
                  onClick={() => displayDropdown("chat")}
                  size="large"
                  name="chatbubble-outline"
                ></ion-icon>
                {messages.length > 0 && (
                  <span className="mini">
                    {messages.length > 100 ? "n" : messages.length}
                  </span>
                )}
              </div>
              <div className="user">
                <ion-icon
                  onClick={() => displayDropdown("user")}
                  size="large"
                  name="person-circle-outline"
                ></ion-icon>
              </div>
            </div>
            <div className="user-drop-down hidden" id="user-dropdown">
              <ul className="noselect">
                {account && <li>Xin chào {account.username}</li>}
                <li>
                  <Link to={`${path}/setting`}>
                    Tài khoản <ion-icon name="person-outline"></ion-icon>
                  </Link>
                </li>
                <li>
                  <Link to={"/stats"}>
                    Thống kê <ion-icon name="bar-chart-outline"></ion-icon>
                  </Link>
                </li>
                <li>
                  <Link to={"#"} onClick={logout}>
                    Đăng xuất <ion-icon name="log-out-outline"></ion-icon>
                  </Link>
                </li>
              </ul>
            </div>
            <div className="chat-drop-down hidden" id="message-dropdown">
              <ul>
                {messages.map((unseen, idx) => (
                  <li key={idx}>
                    <Link to={`${path}/menu/chat?id=${unseen.hostId}`}>
                      Bạn có tin nhắn mới từ {unseen.title}
                    </Link>
                  </li>
                ))}
              </ul>
              <div className="text-center">
                <Link to={`${path}/menu/chat`}>Xem tất cả</Link>
              </div>
            </div>
            <div className="notify-drop-down hidden" id="notification-dropdown">
              <ul>
                {notification.map((notify, idx) => (
                  <li onClick={() => seenNotify(notify)} key={idx}>
                    {notify.content}
                  </li>
                ))}
              </ul>
              <div className="text-center">
                <Link to={`${path}/setting`}>Xem tất cả</Link>
              </div>
            </div>
          </div>

          <div className="app" id="app">
            <div
              className="background"
              style={{ backgroundImage: `url(${"/img/background.png"})` }}
            >
              {/* <img src="/img/background.png" alt="" /> */}
            </div>
            {isLoading && (
              <LoadingComponent
                type={"circle"}
                timelapse={1500}
                end={() => setIsLoading(false)}
              ></LoadingComponent>
            )}
            {!isLoading && (
              <>
                <div ref={footerRef}>
                  <BreadcrumbComponent></BreadcrumbComponent>
                </div>
                <Switch>
                  <Route exact path={`${path}`}>
                    <HomePage></HomePage>
                  </Route>
                  <Route exact path={`${path}/chat`}>
                    <ChatPage></ChatPage>
                  </Route>
                  <Route path={`${path}/meeting/:meetingId`}>
                    <LobbyPage></LobbyPage>
                  </Route>
                  <Route path={`${path}/learn`}>
                    <Switch>
                      <Route path={`${path}/learn`} exact>
                        <LearnPage></LearnPage>
                      </Route>
                      <Route path={`${path}/learn/:id`}>
                        <Switch>
                          <Route
                            path={`${path}/learn/:id/:subjectId`}
                          >

                            <Switch>
                              <Route
                                path={`${path}/learn/:id/:subjectId`}
                                exact
                              >
                                <LearnDetailPage></LearnDetailPage>
                              </Route>
                              <Route path={`${path}/learn/:id/:subjectId/report`}>
                                <ProjectReportPage></ProjectReportPage>
                              </Route>
                            </Switch>
                          </Route>
                          <Route
                            path={`${path}/learn/:id/:subjectId/exam`}
                          >
                            <Switch>
                              <Route
                                exact
                                path={`${path}/learn/:id/:subjectId/exam`}
                              >
                                <ExamPage></ExamPage>
                              </Route>
                              <Route
                                path={`${path}/learn/:id/:subjectId/exam/:examId`}
                              >
                                <DoExamPage></DoExamPage>
                              </Route>
                            </Switch>
                          </Route>
                          <Route path={`${path}/learn/:id/progress`}>
                            <LearnDashboardPage></LearnDashboardPage>
                          </Route>
                        </Switch>
                      </Route>
                    </Switch>
                  </Route>
                  <Route path={`${path}/menu`}>
                    <Route exact path={`${path}/menu`}>
                      <MenuPage MySwal={MySwal}></MenuPage>
                    </Route>
                    <Switch>
                      <Route path={`${path}/menu/schedule`}>
                        <SchedulePage></SchedulePage>
                      </Route>
                      <Route path={`${path}/menu/attendance`}>
                        <AttendancePage></AttendancePage>
                      </Route>
                      <Route path={`${path}/menu/ticket`}>
                        <TicketPage></TicketPage>
                      </Route>
                      <Route path={`${path}/menu/chat`}>
                        <ChatPage></ChatPage>
                      </Route>
                      <Route path={`${path}/menu/jira`}>
                        <JiraPage></JiraPage>
                      </Route>
                      <Route path={`${path}/menu/log-work`}>
                        <LogworkPage></LogworkPage>
                      </Route>
                      <Route path={`${path}/menu/exam`}>
                        <ExamPage></ExamPage>
                      </Route>
                      <Route path={`${path}/menu/meeting`}>
                        <LobbyPage></LobbyPage>
                      </Route>
                      <Route path={`${path}/menu/domain`}>
                        <SelfDomainManage></SelfDomainManage>
                      </Route>
                      <Route path={`${path}/menu/manage-question`}>
                        <QuestionManagePage></QuestionManagePage>
                      </Route>
                      <Route path={`${path}/menu/manage-task`}>
                        <TaskManagePage></TaskManagePage>
                      </Route>
                      <Route path={`${path}/menu/manage-global-domain`}>
                        <DomainManagePage></DomainManagePage>
                      </Route>
                      <Route path={`${path}/menu/manage-class`}>
                        <Switch>
                          <Route exact path={`${path}/menu/manage-class`}>
                            <ClassManagePage></ClassManagePage>
                          </Route>
                          <Route path={`${path}/menu/manage-class/:id`}>
                            <ClassManageDetailPage></ClassManageDetailPage>
                          </Route>
                        </Switch>
                      </Route>
                      <Route path={`${path}/menu/manage-subject`}>
                        <Switch>
                          <Route exact path={`${path}/menu/manage-subject`}>
                            <SubjectManagePage></SubjectManagePage>
                          </Route>
                          <Route path={`${path}/menu/manage-subject/:id`}>
                            <SubjectManageDetailPage></SubjectManageDetailPage>
                          </Route>
                        </Switch>
                      </Route>
                      <Route path={`${path}/menu/manage-ticket`}>
                        <TicketManagePage></TicketManagePage>
                      </Route>
                      <Route path={`${path}/menu/manage-hr`}>
                        <HRManagePage></HRManagePage>
                      </Route>
                      <Route path={`${path}/menu/manage-component`}>
                        <ComponentManagePage></ComponentManagePage>
                      </Route>
                      <Route path={`${path}/menu/report`}>
                        <Switch>
                          <Route exact={true} path={`${path}/menu/report`}>
                            <ReportHomePage></ReportHomePage>
                          </Route>
                          <Route path={`${path}/menu/report/task`}>

                          </Route>
                          <Route path={`${path}/menu/report/ticket`}>
                            <TicketReportPage></TicketReportPage>
                          </Route>
                          <Route path={`${path}/menu/report/project`}>
                            <ProjectReportPage></ProjectReportPage>
                          </Route>
                          <Route path={`${path}/menu/report/class`}>
                            <ClassReportPage></ClassReportPage>
                          </Route>
                        </Switch>
                      </Route>
                    </Switch>
                  </Route>
                  <Route path={`${path}/setting`}>
                    <SettingPage></SettingPage>
                  </Route>
                </Switch>
              </>
            )}
          </div>
          <div>
            <FooterComponent></FooterComponent>
          </div>
        </div>
      </div>
    </div>
  );
};

export default WrapperComponent;
