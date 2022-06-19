import {AnyAction} from "redux";
import {User} from "../../models/User";

export enum AuthTypes {
    LOGIN_SUCCESS = 1,
    LOGIN_FAILURE,
    LOGOUT_FAILURE,
    LOGOUT,
    REGISTER_SUCCESS,
    REGISTER_FAILURE,
}

export interface AuthAction extends AnyAction {
    user: User|null
}
