import {AuthState} from "./auth/AuthReducer";
import {AlertState} from "./alert/AlertReducer";
import {TreesState} from "./tree/TreeReducer";

export interface IAppState {
    auth: AuthState,
    alert: AlertState,
    trees: TreesState
}