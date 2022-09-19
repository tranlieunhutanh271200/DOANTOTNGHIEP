import { useEffect, useRef, useState } from "react";
import PaginationComponent from "../../components/pagination/pagination.component";
import axiosClient from "../../global/axios/axiosClient";
import "./chat.css";
import messageConnection from "../../services/message.service";
import { useSelector } from "react-redux";
import { HubConnectionState } from "@microsoft/signalr";
import { useHistory, useParams } from "react-router-dom";
import { ROLE } from "../../consts/role.const";
function ChatPage() {
  const [users, setUsers] = useState([]); //Previous chat users
  const [message, setMessage] = useState("");
  const [currentChat, setCurrentChat] = useState({});
  const { location } = useHistory();
  const { account } = useSelector((x) => x.auth);
  const {data} = useSelector(x => x.auth);
  const [refresh, setRefresh] = useState(false);
  const [conversations, setConversations] = useState([]);
  const query = new URLSearchParams(location.search);
  const messageRef = useRef();
  const chatboxRef = useRef();
  useEffect(() => {
    if (messageConnection.state === HubConnectionState.Disconnected) {
      messageConnection.start();
    }
    messageConnection.on("newmessage", () => {
      console.log("new message incoming");
      setRefresh(!refresh);
    });
    console.log(query.get("id"));
  }, []);
  const [teachers,setTeachers] = useState([])
  const [students,setStudents] = useState([]);
  useEffect(() => {
    const fetchData = async () => {
      const result = await axiosClient.get(
        `/api/CRM/conversations?accountId=${
          account?.id || "B36C2A83-AABD-40C3-6B72-08DA3503CE41"
        }`
      );
      console.log(result);
      if (query.get("id")) {
        const id = query.get("id");
        console.log(result.find((x) => x.hostId === id || x.memberId === id));
        if (!result.find((x) => x.hostId === id || x.memberId === id)) {
          let tempConversation;
          if(account.role === ROLE.STUDENT){
            const teacher = await axiosClient.get(`/api/course/teachers/${id}`)
            tempConversation = {
              id: -1,
              title: teacher.teacher.fullName,
              hostId: account.id,
              hostFullname: data.student.fullName,
              memberFullname: teacher.teacher.fullName,
              memberId: id,
              messages: [],
            };
          }
          if(account.role === ROLE.TEACHER){
            const student = await axiosClient.get(`/api/course/students/${id}`)
            tempConversation = {
              id: -1,
              title: student.student.fullName,
              hostId: account.id,
              hostFullname: data.teacher.fullName,
              memberFullname: student.student.fullName,
              memberId: id,
              messages: [],
            };
          }
          console.log(tempConversation);
          setConversations([tempConversation, ...result]);
          setCurrentConversation(tempConversation);
          query.delete("id");
        } else {
          setConversations(result);
          setCurrentConversation(
            result.find((x) => x.hostId === id || x.memberId === id)
          );
        }
      } else {
        setConversations(result);
      }
      if (currentconversation != null) {
        setCurrentConversation(
          result.find((x) => x.id === currentconversation.id)
        );
      }
    };
    fetchData();
  }, [refresh]);
  const [currentconversation, setCurrentConversation] = useState(null);
  useEffect(() => {
    chatboxRef.current?.scrollIntoView({ behavior: "smooth" });
  }, [setCurrentConversation, currentconversation]);

  const send = async (e) => {
    e.preventDefault();
    //Send messsage using signalR
    const data = {
      senderId: account.id,
      receiverId:
        currentconversation.hostId === account.id
          ? currentconversation.memberId
          : currentconversation.hostId,
      content: message,
      hostFullname: currentconversation.hostFullname,
      memberFullname: currentconversation.memberFullname,
      domainId: account.domain.id
    };
    console.log(data);
    const result = await axiosClient.post(
      `/api/CRM/conversations/${currentconversation.id}/send`,
      data
    );
    console.log(result);
    if (result) {
      setRefresh(!refresh);
    }
    setMessage("");
    messageRef.current.value = "";
  };
  const select = (user) => {
    setCurrentChat(user);
  };
  useEffect(() => {
    const seen = async () => {
      var result = await axiosClient.put(
        `/api/crm/conversations/${currentconversation.id}/seen?accountId=${account.id}`
      );
      if (result.status === 200) {
        console.log("Thành công");
      }
    };
    if (!query.get("id") && currentconversation) {
      seen();
    }
  }, [currentconversation, setCurrentConversation]);
  return (
    <div className="chat_page">
      <div className="group">
        <div className="users">
          <div className="search_box">
            <input
              type="text"
              placeholder="Search chat"
              name="search"
              autoSave="false"
              autoComplete="false"
            />
            <ion-icon size="large" name="search-outline"></ion-icon>
          </div>
          <ul>
            {conversations.map((conversation, idx) => (
              <li
                key={idx}
                onClick={() => setCurrentConversation(conversation)}
                className={currentconversation === conversation ? 'active': ''}
              >
                <img
                  className="avatar"
                  src="/img/female-default-avatar-3.png"
                  alt="avatar"
                />
                <span className="chat-detail">
                  <div className="name">{account.id === conversation.hostId ? conversation.memberFullname : conversation.hostFullname}</div>
                  <p className="last_message">
                    {
                      conversation.messages[conversation.messages.length - 1]
                        ?.content
                    }
                  </p>
                </span>
              </li>
            ))}
          </ul>
        </div>
        <div className="chatbox">
          {currentconversation != null && (
            <>
              <div className="current_user">
                <img
                  className="avatar"
                  src="/img/female-default-avatar-3.png"
                  alt="avatar"
                />
                <h4>{currentconversation.hostId === account.id ? currentconversation.memberFullname : currentconversation.hostFullname}</h4>
              </div>
              <div className="chat_area">
                {currentconversation.messages.map((message, idx) => (
                  <div
                    key={idx}
                    className={`cover  ${
                      (account?.id ||
                        "e234b73c-d762-403e-6b73-08da3503ce41") ===
                      message.senderId
                        ? "send"
                        : "receive"
                    }`}
                  >
                    <div className={`bubble_chat`}>{message?.content}</div>
                  </div>
                ))}
                <div ref={chatboxRef}></div>
              </div>
              <div className="type">
                <textarea
                  ref={messageRef}
                  onChange={(e) => setMessage(e.target.value)}
                  name="Text1"
                  cols="40"
                  rows="1"
                  placeholder="Enter your message here"
                  defaultValue={message}
                ></textarea>
                <button onClick={(e) => send(e)}>
                  <ion-icon name="send-outline"></ion-icon>
                </button>
              </div>
            </>
          )}
        </div>
      </div>
    </div>
  );
}

export default ChatPage;
