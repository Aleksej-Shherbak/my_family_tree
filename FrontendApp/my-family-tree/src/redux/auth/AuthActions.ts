import {AnyAction} from "redux";
import {ThunkDispatch} from "redux-thunk";
import {User} from "../../models/User";
import axios from "axios";
import {AuthActions, AuthTypes} from "./AuthTypes";
import {alertActions} from "../alert/AlertActions";
import {LoginRequest} from "../../Requests/Auth/LoginRequest";
import {RegisterRequest} from "../../Requests/Auth/RegisterRequest";
import {Token} from "../../models/Token";
import {BaseResponse} from "../../Responses/BaseResponse";

export const authActions = {
    login,
    logout,
    register,
};

function login(request: LoginRequest) {
    return async (dispatch: ThunkDispatch<{}, {}, AnyAction>): Promise<void> => {
        try {
            const response = await axios.post<LoginRequest, BaseResponse<Token>>('http:ya.ru', request);

            if (response.isSuccess) {
                // TODO do something with response
            } else {
                dispatch(failure())
                dispatch(alertActions.error(response.message))
            }
        } catch (e) {
            dispatch(failure())
            // TODO check it
            dispatch(alertActions.error(e as string))
        }
    };

    function success(user: User): AuthActions {
        return {type: AuthTypes.LOGIN_SUCCESS, user}
    }

    function failure(): AuthActions {
        return {type: AuthTypes.LOGIN_FAILURE, user: null}
    }
}

function logout(): AuthActions {
    localStorage.removeItem('user');
    return {type: AuthTypes.LOGOUT, user: null};
}

function register(request: RegisterRequest) {

    return async (dispatch: ThunkDispatch<{}, {}, AnyAction>): Promise<void> => {
        try {
            const response = await axios.post<RegisterRequest, BaseResponse<Token>>('http:ya.ru', request);

            if (response.isSuccess) {
                // TODO do soemthing with token
            } else {
                dispatch(failure())
                dispatch(alertActions.error(response.message))
            }
        } catch (e) {
            dispatch(failure())
            // TODO check it
            dispatch(alertActions.error(e as string))
        }

        function success(user: User): AuthActions {
            return {type: AuthTypes.REGISTER_SUCCESS, user}
        }

        function failure(): AuthActions {
            return {type: AuthTypes.REGISTER_FAILURE, user: null}
        }
    }
}
