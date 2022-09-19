import { AuthReducer } from './auth.reducer'
import { combineReducers } from 'redux'
import { CustomizeReducer } from './customize.reducer';
import { SubjectReducer } from './subject.reducer';
const rootReducer = combineReducers({
    auth: AuthReducer,
    customize: CustomizeReducer,
    subject: SubjectReducer
})
export {rootReducer};