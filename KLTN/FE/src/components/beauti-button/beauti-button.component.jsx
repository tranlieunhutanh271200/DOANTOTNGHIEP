import { useState } from "react";
import "./beauti-button.css";
export const ButtonType = {
  INFO: "info",
  PRIMARY: "primary",
  SUCCESS: "success",
  WARNING: "warning",
  DANGER: "danger",
};
const BeautiButtonComponent = ({
  buttonType = ButtonType.PRIMARY,
  status,
  action,
  rollback
}) => {
  const [isLoading, setIsLoading] = useState(false);
  const [isDone, setIsDone] = useState(false);
  const loading = () => {
    if (!isDone) {
      setIsLoading(true);
      setTimeout(() => {
        setIsLoading(false);
        setIsDone(true);
        action();
      }, 1000);
    }
    else{
        setIsLoading(true);
        setTimeout(() => {
          setIsLoading(false);
          setIsDone(false);
          rollback();
        }, 1000);
    }
  };
  return (
    <button className={`btn btn-${buttonType}`} onClick={loading}>
      <p className={isLoading ? "rolling" : ""}>
        {!status ? (
          <ion-icon
            size="large"
            name={`${
              isLoading ? "refresh" : isDone ? "checkbox" : "square"
            }`}
          ></ion-icon>
        ) : (
          <ion-icon size="large" name={`${
            isLoading ? "refresh" : isDone ? "checkbox" : "square"}`}></ion-icon>
        )}
      </p>
    </button>
  );
};

export default BeautiButtonComponent;
