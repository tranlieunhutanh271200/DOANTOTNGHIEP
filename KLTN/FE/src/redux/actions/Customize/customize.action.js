export const CUSTOMIZE_ACTION = {
  LOAD_CUSTOMIZE: "LOAD_CUSTOMIZE",
  CHANGE_CUSTOMIZE: "CHANGE_CUSTOMIZE",
};
export const loadCustomize = (style) => {
  return dispatch => {
    console.log("Load customize data for user");
    return dispatch({ data: style, type: CUSTOMIZE_ACTION.LOAD_CUSTOMIZE });
  };
};
