import {combineReducers} from "redux";
import {authReducer} from "./auth/AuthReducer";
import {alertReducer} from "./alert/AlertReducer";
import {IAppState} from "./AppStateTypes";

export const rootReducer = combineReducers<IAppState>({
    auth: authReducer,
    alert: alertReducer
}); 