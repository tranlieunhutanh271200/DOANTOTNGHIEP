import { HubConnectionState } from "@microsoft/signalr";
import { ROLE } from "../../consts/role.const";
import messageConnection from "../../services/message.service";
import { AUTH_ACTION } from "../actions/Auth/auth.action";

const INIT_STATE = {
  token: "",
  account: {
    role: ROLE.STUDENT,
    username: "",
    photoImage: "",
  },
  isRefresh: false,
  navigationRefresh: false,
  data: {
    student: {},
    teacher: {},
  },
};

export const AuthReducer = (state = INIT_STATE, action) => {
  switch (action.type) {
    case AUTH_ACTION.LOGIN:
      const parsedData = JSON.parse(action.data);
      localStorage.setItem("token", parsedData.token);
      localStorage.setItem("account", JSON.stringify(parsedData.account));
      return { ...INIT_STATE, ...parsedData };
    case AUTH_ACTION.LOGOUT:
      localStorage.removeItem("account");
      localStorage.removeItem("token");
      localStorage.removeItem("persist:root");
      if (messageConnection.state === HubConnectionState.Connected) {
        messageConnection.send("Logout", {
          accountId: state.account.id,
        });
      }
      return { ...INIT_STATE };
    case AUTH_ACTION.PERSIST:
      const persistData = JSON.parse(localStorage.getItem("persist:root"));
      const data = JSON.parse(persistData.auth);
      console.log(data);
      return { ...state, ...data };
    case AUTH_ACTION.REFRESH:
      console.log("refresh");
      return {
        ...state,
        isRefresh: !state.isRefresh,
      };
    case AUTH_ACTION.NAVIGATION_REFRESH:
      console.log("refresh");
      return {
        ...state,
        navigationRefresh: !state.navigationRefresh,
      };
    default:
      return { ...state };
  }
};
