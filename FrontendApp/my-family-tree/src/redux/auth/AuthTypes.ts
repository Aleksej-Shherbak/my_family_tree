import {AnyAction} from "redux";
import {User} from "../../models/User";

export enum AuthTypes {
    LOGIN_SUCCESS = 'LOGIN_SUCCESS',
    LOGIN_FAILURE = 'LOGIN_FAILURE',
    LOGOUT_FAILURE = 'LOGOUT_FAILURE',
    LOGOUT = 'LOGOUT',
    REGISTER_SUCCESS = 'REGISTER_SUCCESS',
    REGISTER_FAILURE = 'REGISTER_FAILURE',
}

export interface AuthAction extends AnyAction {
    user: User|null
}
