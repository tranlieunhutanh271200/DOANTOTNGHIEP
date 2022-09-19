import { SUBJECT_ACTION } from "../actions/subject/subject.action";

const INIT_STATE = [
    {
        year: 0,
        semesters: [
            {

            }
        ]
    }
]
export const SubjectReducer = (state = INIT_STATE, action) => {
    switch (action.type) {
        case SUBJECT_ACTION.GET_MASTER_DATA:
            
            return {...action.data}
    
        default:
            return {...state}
    }
}