import {combineReducers} from "redux";
import {authReducer} from "./auth/AuthReducer";
import {alertReducer} from "./alert/AlertReducer";

export const rootReducer = combineReducers({
    auth: authReducer,
    alert: alertReducer
}); 