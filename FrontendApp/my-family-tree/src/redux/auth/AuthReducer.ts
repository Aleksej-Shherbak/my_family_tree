import {User} from "../../models/User";
import {AuthAction, AuthTypes} from "./AuthTypes";
import {Reducer} from "redux";

export interface AuthState {
    user: User|null
}

const initialState: AuthState = {
    user: null
}

const userString = localStorage.getItem('user');
if (userString) {
    initialState.user = JSON.parse(userString) as User;
}

export const authReducer: Reducer<AuthState, AuthAction> = (state: AuthState = initialState, action: AuthAction): AuthState => {
    switch (action.type) {
        case AuthTypes.LOGIN_SUCCESS:
            localStorage.setItem('user', JSON.stringify(action.user))
            return {user: action.user};
        case AuthTypes.LOGIN_FAILURE:
            localStorage.removeItem('user');
            return {user: null}
        case AuthTypes.LOGOUT_FAILURE:
            localStorage.removeItem('user');
            return {user: null}
        case AuthTypes.LOGOUT:
            localStorage.removeItem('user');
            return {user: null}
    }
    
    return state;
}