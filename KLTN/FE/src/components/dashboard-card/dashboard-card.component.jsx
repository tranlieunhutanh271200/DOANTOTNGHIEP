import { useEffect, useState } from "react";

const DashboardCardComponent = () => {
  const [cards, setCards] = useState([]);
  useEffect(() => {
    //Load customize card from redux store
  }, []);
  return (
    <div className="cardBox">
      <div className="card">
        <div>
          <div className="numbers">3 classes</div>
          <div className="cardName">Today</div>
        </div>
        <div className="iconBox">
          <ion-icon size="large" name="today-outline"></ion-icon>
        </div>
      </div>
      <div className="card">
        <div>
          <div className="numbers">100 students</div>
          <div className="cardName">Total</div>
        </div>
        <div className="iconBox">
          <ion-icon size="large" name="people-outline"></ion-icon>
        </div>
      </div>
      <div className="card">
        <div>
          <div className="numbers">15 classes</div>
          <div className="cardName">Total</div>
        </div>
        <div className="iconBox">
          <ion-icon size="large" name="browsers-outline"></ion-icon>
        </div>
      </div>
      <div className="card">
        <div>
          <div className="numbers">3 projects</div>
          <div className="cardName">Guilding</div>
        </div>
        <div className="iconBox">
          <ion-icon size="large" name="albums-outline"></ion-icon>
        </div>
      </div>
    </div>
  );
};

export default DashboardCardComponent;
