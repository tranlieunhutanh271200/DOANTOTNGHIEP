import { CUSTOMIZE_ACTION } from "../actions/Customize/customize.action"

const INIT_STATE = {
    style: ''
}

export const CustomizeReducer = (state = INIT_STATE, action) => {
    switch(action.type){
        case CUSTOMIZE_ACTION.LOAD_CUSTOMIZE:
            return {...state, style: action.data};
        default:
            return {...state}
    }
}