import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { Provider } from "react-redux";
import result from "./redux/redux.store";
import { ToastContainer } from "react-toastify";
import { PersistGate } from "redux-persist/integration/react";
import LoadingComponent from "./components/loading/loading.component";
ReactDOM.render(
  <Provider store={result.store}>
    <PersistGate loading={<LoadingComponent/>} persistor={result.persistor}>
      <App />
    </PersistGate>
  </Provider>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
