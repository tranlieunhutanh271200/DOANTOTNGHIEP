export const SUBJECT_ACTION = {
    GET_MASTER_DATA: 'get_master_data'
}
export const getMasterData = (data) => {
    return dispatch => {
        return dispatch({type: SUBJECT_ACTION.GET_MASTER_DATA, data: data.masterdata})
    }
}