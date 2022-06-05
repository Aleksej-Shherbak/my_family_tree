import {Reducer} from "redux";
import {AuthenticatedAction} from "./AuthActions";
import {AuthenticatedEnum} from "./types";

export interface AuthState {
    isAuthenticated: boolean
}

const initialState: AuthState = {
    isAuthenticated: false
}

export const authReducer: Reducer = (state: AuthState = initialState, action: AuthenticatedAction): AuthState => {
    switch (action.type) {
        case AuthenticatedEnum.Authorized:
            return {...state, isAuthenticated: true }
        case AuthenticatedEnum.NotAuthorized:
            return {...state, isAuthenticated: false }
    }
    
    return state;
}