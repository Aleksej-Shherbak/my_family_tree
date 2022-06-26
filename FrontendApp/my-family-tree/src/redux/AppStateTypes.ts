import {AuthState} from "./auth/AuthReducer";
import {AlertState} from "./alert/AlertReducer";
import {TreeListState} from "./tree/TreeListReducer";

export interface IAppState {
    auth: AuthState,
    alert: AlertState,
    trees: TreeListState
}