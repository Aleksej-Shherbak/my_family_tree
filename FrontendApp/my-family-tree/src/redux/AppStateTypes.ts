import {AuthState} from "./auth/AuthReducer";
import {AlertState} from "./alert/AlertReducer";

export interface IAppState {
    auth: AuthState,
    alert: AlertState
}