import {combineReducers} from "redux";
import {authReducer} from "./auth/AuthReducer";

export const rootReducer = combineReducers({
    auth: authReducer
}); 