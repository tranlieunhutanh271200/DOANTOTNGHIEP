import { useEffect, useLayoutEffect, useRef, useState } from "react";
import { useParams, Link, useHistory } from "react-router-dom";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import "./online-meeting.css";
import connection from "../../services/signalr.service";
import Peer from "peerjs";
import { createSocketConnectionInstance } from "../../services/webrtc.service";
import { getObjectFromUrl } from "../../utils/helper";
import { v4 as uuidv4 } from "uuid";
const partipateData = [
  {
    id: 1,
    name: "Nhut Anh",
    studentId: "18116969",
    class: "1811CL3A",
    avatar: "/img/male-default-avatar.png",
    micStatus: false,
    isSharingScreen: false,
    isSharingCamera: true,
  },
  {
    id: 2,
    name: "Nhut Anh",
    studentId: "18116969",
    class: "1811CL3A",
    avatar: "/img/male-default-avatar.png",
    micStatus: true,
    isSharingScreen: false,
    isSharingCamera: false,
  },
  {
    id: 3,
    name: "Nhut Anh",
    studentId: "18116969",
    class: "1811CL3A",
    avatar: "/img/male-default-avatar.png",
    micStatus: false,
    isSharingScreen: false,
    isSharingCamera: false,
  },
  {
    id: 3,
    name: "Nhut Anh",
    studentId: "18116969",
    class: "1811CL3A",
    avatar: "/img/male-default-avatar.png",
    micStatus: false,
    isSharingScreen: false,
    isSharingCamera: false,
  },
  {
    id: 3,
    name: "Nhut Anh",
    studentId: "18116969",
    class: "1811CL3A",
    avatar: "/img/male-default-avatar.png",
    micStatus: false,
    isSharingScreen: false,
    isSharingCamera: false,
  },
];
const OnlineMeetingPage = () => {
  let socketInstance = useRef(null);
  const [stream, setStream] = useState(true);
  const [micStatus, setMicStatus] = useState(true);
  const [camStatus, setCamStatus] = useState(true);
  const [streaming, setStreaming] = useState(false);
  const [chatToggle, setChatToggle] = useState(false);
  const [userDetails, setUserDetails] = useState(null);
  const [displayStream, setDisplayStream] = useState(false);
  const [messages, setMessages] = useState([]);
  const [isHost, setIsHost] = useState(true);
  const [participants, setParticipants] = useState(partipateData);
  const { id } = useParams();
  const history = useHistory();
  const myExitSwal = withReactContent(Swal);
  const myVideo = useRef();
  const userVideo = useRef();
  const [userId, setUserId] = useState(null);
  const [remoteId, setRemoteId] = useState(null);
  const peerInstance = useRef(null);

  useEffect(() => {
    console.log(id);
    // connection.start();
    // connection.send("")
    // navigator.mediaDevices.getUserMedia({ video: true, audio: true }).then(
    //   (stream) => {
    //     myVideo.current.srcObject = stream;
    //   },
    //   (err) => console.log(err)
    // );
    const peer = new Peer(uuidv4());
    console.log(peer);
    peer.on("open", (id) => {
      setUserId(id);
    });
    peer.on("connection", (conn) => {
      conn.on("data", (data) => {
        // Will print 'hi!'
        console.log(data);
      });
      conn.on("open", () => {
        conn.send("hello!");
      });
    });
    peer.on("call", (call) => {
      console.log("incoming call");
      var getUserMedia =
        navigator.getUserMedia ||
        navigator.webkitGetUserMedia ||
        navigator.mozGetUserMedia;

      getUserMedia({ video: true, audio: true }, (mediaStream) => {
        myVideo.current.srcObject = mediaStream;
        call.answer(mediaStream);
        call.on("stream", function (remoteStream) {
          userVideo.current.srcObject = remoteStream;
        });
      });
    });
    peerInstance.current = peer;
  }, []);
  console.log(userId);
  const callUser = (remotePeerId) => {
    var getUserMedia =
      navigator.getUserMedia ||
      navigator.webkitGetUserMedia ||
      navigator.mozGetUserMedia;

    getUserMedia({ video: true, audio: true }, (mediaStream) => {
      myVideo.current.srcObject = mediaStream;
      myVideo.current.play();

      const call = peerInstance.current.call(remotePeerId, mediaStream);

      call.on("stream", (remoteStream) => {
        userVideo.current.srcObject = remoteStream;
      });
    });
  };

  const startConnection = () => {
    let params = getObjectFromUrl();
    if (!params) params = { quality: 12 };
    socketInstance.current = createSocketConnectionInstance({
      updateInstance: updateFromInstance,
      params,
      userDetails,
    });
  };
  const updateFromInstance = (key, value) => {
    if (key === "streaming") setStreaming(value);
    if (key === "message") setMessages([...value]);
    if (key === "displayStream") setDisplayStream(value);
  };
  const exit = () => {
    Swal.fire({
      icon: "error",
      html: "Are you sure?",
      confirmButtonText: "Thoát",
    }).then((result) => {
      if (result.isConfirmed) {
        history.goBack();
      }
    });
  };
  const handleMyMic = () => {
    const { getMyVideo, reInitializeStream } = socketInstance.current;
    const myVideo = getMyVideo();
    if (myVideo)
      myVideo.srcObject?.getAudioTracks().forEach((track) => {
        if (track.kind === "audio")
          // track.enabled = !micStatus;
          micStatus ? track.stop() : reInitializeStream(camStatus, !micStatus);
      });
    setMicStatus(!micStatus);
  };

  const handleMyCam = () => {
    if (!displayStream) {
      const { toggleVideoTrack } = socketInstance.current;
      toggleVideoTrack({ video: !camStatus, audio: micStatus });
      setCamStatus(!camStatus);
    }
  };

  const handleuserDetails = (userDetails) => {
    setUserDetails(userDetails);
  };

  const chatHandle = (bool = false) => {
    setChatToggle(bool);
  };
  const toggleScreenShare = () => {
    const { reInitializeStream, toggleVideoTrack } = socketInstance.current;
    displayStream && toggleVideoTrack({ video: false, audio: true });
    reInitializeStream(
      false,
      true,
      !displayStream ? "displayMedia" : "userMedia"
    ).then(() => {
      setDisplayStream(!displayStream);
      setCamStatus(false);
    });
  };
  const micChange = (student) => {};
  return (
    <div className="online-meeting">
      <div className="main-screen">
        <h1>Current user id is {userId}</h1>
        <input
          className="form-field"
          type="text"
          onChange={(e) => setRemoteId(e.target.value)}
        />
        <div className="stream-config">
          <div className="counter">0:00</div>
          <div className="function">
            <span>
              <ion-icon size="large" name="people-outline"></ion-icon>
            </span>
            <span>
              <ion-icon size="large" name="chatbox-ellipses-outline"></ion-icon>
            </span>
            <span>
              <ion-icon size="large" name="hand-left-outline"></ion-icon>
            </span>
            <span>
              <ion-icon
                size="large "
                name="ellipsis-horizontal-outline"
              ></ion-icon>
            </span>
            <i className="splitter"></i>
            <span>
              <ion-icon size="large" name="videocam-outline"></ion-icon>
            </span>
            <span onClick={() => setMicStatus(!micStatus)}>
              {micStatus ? (
                <ion-icon size="large" name="mic-off-outline"></ion-icon>
              ) : (
                <ion-icon size="large" name="mic-outline"></ion-icon>
              )}
            </span>
            <span>
              <ion-icon size="large" name="share-outline"></ion-icon>
            </span>
            <button
              onClick={() => callUser(remoteId)}
              className="btn btn-danger btn-beautiful icon-rotate-45"
            >
              <ion-icon name="call-outline"></ion-icon>
            </button>
          </div>
        </div>
        <div className="stream-screen">
          {stream && (
            <video
              playsInline
              muted
              ref={myVideo}
              autoPlay
              style={{ width: "100%", height: "100%" }}
            ></video>
          )}
        </div>
      </div>
      <div className="participants">
        {participants.map((student, idx) => (
          <div className="student" key={idx}>
            {!student.isSharingCamera ? (
              <>
                {" "}
                <div className="avatar">
                  <img
                    alt={`student ${student.studentId} avatar`}
                    src={student.avatar}
                  />
                </div>
                <div className="name">{student.name}</div>
                <div className="studentId">{student.studentId}</div>
                <div className="mic" onClick={() => micChange(student)}>
                  {student.micStatus ? (
                    <ion-icon size="large" name="mic-outline"></ion-icon>
                  ) : (
                    <ion-icon size="large" name="mic-off-outline"></ion-icon>
                  )}
                </div>
                <span className="more">
                  <ion-icon
                    size="large"
                    name="ellipsis-vertical-outline"
                  ></ion-icon>
                </span>
              </>
            ) : (
              <div className="box">
                <span className="pin">
                  <ion-icon size="large" name="pin-outline"></ion-icon>
                </span>
                {stream && (
                  <video
                    playsInline
                    muted
                    ref={userVideo}
                    autoPlay
                    style={{ width: "100%", height: "100%" }}
                  ></video>
                )}
              </div>
            )}
          </div>
        ))}
      </div>
      <div className="chat-box"></div>
    </div>
  );
};

export default OnlineMeetingPage;
