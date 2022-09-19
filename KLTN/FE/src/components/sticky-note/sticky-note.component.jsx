import "./sticky-note.css";
import { useRef, useState } from "react";
import SunEditor from "suneditor-react";
import parse from "html-react-parser";
const StickyNoteComponent = ({ note, save, remove }) => {
  const colors = [
    {
      name: "yellow",
      value: "rgba(234, 218, 21, 0.75)",
    },
    {
      name: "red",
      value: "rgba( 208, 2, 27, 0.75 )",
    },
    {
      name: "pink",
      value: "rgba( 189, 16, 224, 0.75 )",
    },
  ];
  const [className, setClassName] = useState("");
  const noteRef = useRef();
  const [position, setPosition] = useState({
    x: Number.parseInt(note.xPosition),
    y: Number.parseInt(note.yPosition),
  });
  const [currentNote, setCurrentNote] = useState(note);
  const setDragCursor = (value) => {
    const html = document.getElementsByClassName("grabable").item(0);
    html.classList.toggle("grabbing", value);
  };
  function onDrop(ev) {
    if (
      ev.clientX < ev.view.innerWidth - 35 &&
      ev.clientX > 0 &&
      ev.clientY < ev.view.innerHeight &&
      ev.clientY > 0
    ) {
      setPosition({ ...position, x: ev.clientX - 50, y: ev.clientY - 50 });
      setDragCursor(false);
      setCurrentNote({
        ...currentNote,
        xPosition: ev.clientX - 50,
        yPosition: ev.clientY - 50,
      });
    }
  }
  console.log(currentNote);
  const [isEdit, setIsEdit] = useState(false);
  return (
    <div
      style={{
        top: position.y + "px",
        left: position.x + "px",
        background: colors.find((x) => x.name === currentNote.color).value,
      }}
      onDrag={() => setDragCursor(true)}
      draggable={!isEdit}
      className={`sticky-note grabable noselect`}
      ref={noteRef}
      onDragEnd={(e) => {
        if (!isEdit) {
          onDrop(e);
        }
      }}
      onDoubleClick={() => setIsEdit(!isEdit)}
    >
      <span>
        {!isEdit ? (
          parse(currentNote.content)
        ) : (
          <SunEditor
            name="detail"
            height="100%"
            onChange={(e) => setCurrentNote({ ...currentNote, content: e })}
            defaultValue={currentNote.content}
          />
        )}
        {isEdit && (
          <>
            <div className="form-group d-center">
              <label>Vàng</label>
              <input
                type="radio"
                name="color"
                value={"yellow"}
                className="m-1"
                onChange={(e) =>
                  setCurrentNote({ ...currentNote, color: e.target.value })
                }
                defaultChecked={currentNote.color === "yellow"}
              />
              <label>Đỏ</label>
              <input
                type="radio"
                name="color"
                value={"red"}
                className="m-1"
                onChange={(e) =>
                  setCurrentNote({ ...currentNote, color: e.target.value })
                }
                defaultChecked={currentNote.color === "red"}
              />
              <label>Hồng</label>
              <input
                type="radio"
                name="color"
                value={"pink"}
                className="m-1"
                onChange={(e) =>
                  setCurrentNote({ ...currentNote, color: e.target.value })
                }
                defaultChecked={currentNote.color === "pink"}
              />
            </div>
            <div className="align-center" style={{flexDirection: 'row'}}>
              <ion-icon onClick={() => remove(currentNote.id)} size="large" name="trash-outline"></ion-icon>
              <button
                onClick={() => {
                  setIsEdit(false);
                  save(currentNote);
                }}
                className="noselect primary text-center"
              >
                <span className="text">Lưu</span>
                <span className="icon">
                  <ion-icon size="large" name="save-outline"></ion-icon>
                </span>
              </button>
            </div>
          </>
        )}
      </span>
    </div>
  );
};

export default StickyNoteComponent;
