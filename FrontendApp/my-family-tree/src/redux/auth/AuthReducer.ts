import {User} from "../../models/User";
import {AuthActions, AuthTypes} from "./AuthTypes";

export interface AuthState {
    user: User|null
}

const initialState: AuthState = {
    user: null
}

// TODO move it to a service
const userString = localStorage.getItem('user');
if (userString) {
    initialState.user = JSON.parse(userString) as User;
}

export const authReducer = (state: AuthState = initialState, action: AuthActions): AuthState => {
    switch (action.type) {
        case AuthTypes.LOGIN_REQUEST:
            return {user: action.user};
        case AuthTypes.LOGIN_SUCCESS:
            return {user: action.user};
        case AuthTypes.LOGIN_FAILURE:
            return {user: null}
        case AuthTypes.LOGOUT:
            return {user: null}
    }
    
    return state;
}