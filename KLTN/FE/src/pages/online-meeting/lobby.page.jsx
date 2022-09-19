import "./lobby.css";
import Switch from "react-switch";
import { useEffect, useRef, useState } from "react";
import connection from "../../services/signalr.service";
import { HubConnectionState } from "@microsoft/signalr";
import messageConnection from "../../services/message.service";
import { useParams } from "react-router-dom";
import { useSelector } from "react-redux";

const LobbyPage = () => {
  const [cameraOn, setCameraOn] = useState(false);
  const [micOn, setMicOn] = useState(false);
  const currentStream = useRef();
  const switchCamera = () => {
    if (cameraOn) {
      if (currentStream.current) {
        const tracks = currentStream.current.srcObject.getTracks();

        tracks.forEach(function (track) {
          if (track.kind === "video") {
            track.stop();
          }
        });
      }
    }
    setCameraOn(!cameraOn);
  };
  const switchMic = () => {
    if (micOn) {
      const tracks = currentStream.current?.srcObject.getAudioTracks();
      console.log(tracks);
      tracks.forEach(function (track) {
        track.stop();
      });
    }
    setMicOn(!micOn);
  };
  useEffect(() => {
    console.log(cameraOn);
    console.log(micOn);
    if (cameraOn || micOn) {
      navigator.getUserMedia(
        {
          video: cameraOn,
          audio: micOn,
        },
        (stream) => {
          currentStream.current.srcObject = stream;
        }
      );
    }
    // if(!cameraOn){
    //     currentStream?.current?.getVideoTracks()[0].stop();
    // }
  }, [cameraOn, micOn]);
  const { meetingId } = useParams();
  const { account, data } = useSelector(x => x.auth);
  useEffect(() => {
    if (messageConnection.state === HubConnectionState.Disconnected) {
      connection.start();
    }
    messageConnection.on('connect', (result) => {
      console.log(result);
    });
    messageConnection.on('test', (result) => {
      console.log(result);
    });
    if (meetingId) {
      messageConnection.send("RTCConnect", {
        ...data.student,
        meetingId: meetingId
      });
    }
  }, [])
  return (
    <div className="lobby-page">
      <div className="lobby-box">
        <div className="box-header text-center">
          <h2 onClick={() => connection.send("RTCConnect")}> Vui lòng chờ host cho phép bạn tham gia</h2>
        </div>
        <div className="box-body">
          {cameraOn ? (
            <video
              style={{ width: "100%", height: "100%" }}
              autoPlay
              playsInline
              ref={currentStream}
            ></video>
          ) : (
            <ion-icon ref={currentStream} name="person-circle-outline"></ion-icon>
          )}
        </div>
        <div className="box-footer">
          <div className="control">
            {cameraOn ? (
              <ion-icon size="large" name="videocam-outline"></ion-icon>
            ) : (
              <ion-icon size="large" name="videocam-off-outline"></ion-icon>
            )}
            <Switch
              onColor="#8b8cc7"
              uncheckedIcon={false}
              checkedIcon={false}
              onChange={switchCamera}
              checked={cameraOn}
            />
          </div>
          <div className="control">
            {micOn ? (
              <ion-icon size="large" name="mic-outline"></ion-icon>
            ) : (
              <ion-icon size="large" name="mic-off-outline"></ion-icon>
            )}
            <Switch
              onColor="#8b8cc7"
              uncheckedIcon={false}
              checkedIcon={false}
              onChange={switchMic}
              checked={micOn}
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default LobbyPage;
