import "./context-script.css";
import parse from "html-react-parser";
import SunEditor from "suneditor-react";
import { ConsoleLogger } from "@microsoft/signalr/dist/esm/Utils";
import { useEffect, useState } from "react";
const ContextScriptComponent = ({
  script,
  isModifiable,
  valueChange,
  remove,
  save
}) => {
  const [data,setData] = useState(script);
  useEffect(() => {
    setData(script);
  }, [script])
  return (
    <>
      <div className={isModifiable ? "edit-mode" : ""}>
        <div className="context-script">
          <div className="context-heading">
            {!isModifiable ? (
              <span>{parse(data.heading)}</span>
            ) : (
              <SunEditor
                name="detail"
                height="100%"
                onInput={(e) => setData({...data,heading: e.target.firstChild.outerHTML})}
                defaultValue={script.heading}
              />
            )}
          </div>
          <div className="context-body">
            {!isModifiable ? (
              <span>{parse(data.body)}</span>
            ) : (
              <SunEditor
                name="detail"
                height="100%"
                onInput={(e) => setData({...data,body: e.target.firstChild.outerHTML})}
                defaultValue={script.body}
              />
            )}
          </div>
          <div className="context-footer">
            {" "}
            {!isModifiable ? (
              <span>{parse(data.footer)}</span>
            ) : (
              <SunEditor
                name="detail"
                height="100%"
                onInput={(e) => setData({...data,footer: e.target.firstChild.outerHTML})}
                defaultValue={script.footer}
              />
            )}
          </div>
        </div>
        {isModifiable && (
          <>
            <div className="save">
              <ion-icon
                size="large"
                onClick={() => save(data)}
                name="cloud-upload-outline"
              ></ion-icon>
            </div>
            <div className="remove">
              <ion-icon
                size="large"
                onClick={() => remove(script)}
                name="trash-bin-outline"
              ></ion-icon>
            </div>
          </>
        )}
      </div>
    </>
  );
};

export default ContextScriptComponent;
