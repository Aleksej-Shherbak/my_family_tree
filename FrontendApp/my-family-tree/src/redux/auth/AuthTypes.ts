import {Action} from "redux";
import {User} from "../../models/User";

export enum AuthTypes {
    LOGIN_REQUEST = 1,
    LOGIN_SUCCESS,
    LOGIN_FAILURE,
    LOGOUT,
    REGISTER_SUCCESS,
    REGISTER_FAILURE,
}

export interface AuthActions extends Action<AuthTypes> {
    user: User|null
}
