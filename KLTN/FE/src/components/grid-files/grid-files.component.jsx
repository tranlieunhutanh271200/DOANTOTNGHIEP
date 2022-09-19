import { ACTION } from "../../consts/action.const";
import "./grid-files.css";
import { useEffect, useState } from "react";
export const FILETYPE = {
  PDF: "pdf",
  WORD: "docx|doc",
};
const test_files = [
  {
    id: 0,
    title: "Tài liệu 1",
    type: "pdf",
    url: "url",
  },
  {
    id: 1,
    title: "Tài liệu 2",
    type: "pdf",
    url: "url",
  },
  {
    id: 2,
    title: "Tài liệu 3",
    type: "pdf",
    url: "url",
  },
  {
    id: 3,
    title: "Tài liệu 3",
    type: "pdf",
    url: "url",
  },
  {
    id: 4,
    title: "Tài liệu 3",
    type: "pdf",
    url: "url",
  },
  {
    id: 5,
    title: "Tài liệu 3",
    type: "pdf",
    url: "url",
  },
  {
    id: 6,
    title: "Tài liệu 3",
    type: "pdf",
    url: "url",
  },
  {
    id: 7,
    title: "Tài liệu 3",
    type: "pdf",
    url: "url",
  },
  {
    id: 8,
    title: "Tài liệu 3",
    type: "pdf",
    url: "url",
  },
];
const GridFilesComponent = ({
  files,
  toggle,
  isModifiable,
  removeSubmit,
}) => {
  const [data, setData] = useState(files);
  useEffect(() => {
    setData(files);
  }, [files])
  return (
    <>
      <h3>Tài liệu</h3>
      <div className="grid-files">
        {data.map((file, idx) => (
          <div key={idx} className={`${isModifiable ? "edit-border" : ""}`}>
            <div className="file" onClick={() => 
            {
              if(!isModifiable){
                toggle(ACTION.OPENFILE, file)
              }else{
                toggle(ACTION.EDITFILE, file)
              }
            }}>
              <h4>{file.documentTitle}</h4>
              <div>
                <ion-icon
                  size="large"
                  name="document-attach-outline"
                ></ion-icon>
              </div>
            </div>
            {isModifiable && (
              <div className="remove">
                <ion-icon
                  size="large"
                  onClick={() => removeSubmit(file)}
                  name="trash-outline"
                ></ion-icon>
              </div>
            )}
          </div>
        ))}
      </div>
    </>
  );
};

export default GridFilesComponent;
