import { useEffect } from 'react';
import './loading.css'
function LoadingComponent({ type = "circle" | "wave", timelapse , end}) {
  useEffect(() => {
    var interval = setInterval(() => {
      if(end){
        end();
      }
    },timelapse)
    return () => clearInterval(interval);
  }, []);
  return (
    <div className="loading">
      {type === "circle" && <div className="circle"></div>}
      {type === "wave" && (
        <div className="wave">
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          <span></span>
        </div>
      )}
    </div>
  );
}

export default LoadingComponent;
