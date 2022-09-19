import axiosClient from "../../../global/axios/axiosClient";
export const AUTH_ACTION = {
  LOGIN: "login",
  REGISTER: "register",
  FORGOT_PASSWORD: "forgot-password",
  LOGOUT: 'logout',
  REFRESH: 'refresh',
  PERSIST: 'persistdata',
  NAVIGATION_REFRESH: 'navigation-refresh'
}
export const signIn = (data) => {
  return dispatch => {
    return dispatch({ data: data, type: AUTH_ACTION.LOGIN });
  };
};

export const signOut = () => {
  return dispatch => {
    return dispatch({ type: AUTH_ACTION.LOGOUT });
  };
}
export const refresh = () => {
  return dispatch => {
    return dispatch({type: AUTH_ACTION.REFRESH})
  }
}
export const refreshNavigation = () => {
  return dispatch => {
    return dispatch({type: AUTH_ACTION.NAVIGATION_REFRESH})
  }
}
export const persist = async () => {
  return dispatch => {
    return dispatch({type: AUTH_ACTION.PERSIST});
  }
}