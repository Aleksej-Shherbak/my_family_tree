import {AnyAction, Dispatch} from "redux";
import {ThunkDispatch} from "redux-thunk";
import axios, {AxiosError, AxiosResponse} from "axios";
import {AuthAction, AuthTypes} from "./AuthTypes";
import {alertActions} from "../alert/AlertActions";
import {LoginRequest} from "../../Requests/Auth/LoginRequest";
import {RegisterRequest} from "../../Requests/Auth/RegisterRequest";
import {BASE_URL, LOGIN_URL, REGISTER_URL} from "../../constants/backend";
import {AlertAction} from "../alert/AlertTypes";
import {User} from "../../models/User";
import {ErrorResponse} from "../../models/ErrorResponse";

export const authActions = {
    login,
    logout,
    register,
};

function login(request: LoginRequest) {
    return async (dispatch: Dispatch<AuthAction|AlertAction>): Promise<void> => {
        try {
            const response = await axios.post<LoginRequest, AxiosResponse<User>>(`${BASE_URL}${LOGIN_URL}`, request, {withCredentials: true});
            await dispatch(success(response.data));
        } catch (error) {
            const err = error as AxiosError<ErrorResponse>;
            await dispatch(failure())
            await dispatch(alertActions.error(err.response?.data.error ?? 'Login error.'));
        }
    };

    function success(user: User): AuthAction {
        return {type: AuthTypes.LOGIN_SUCCESS, user}
    }

    function failure(): AuthAction {
        return {type: AuthTypes.LOGIN_FAILURE, user: null}
    }
}

function logout(): AuthAction {
    return {type: AuthTypes.LOGOUT,  user: null};
}

function register(request: RegisterRequest) {

    return async (dispatch: ThunkDispatch<{}, {}, AnyAction>): Promise<void> => {
        try {
            const response = await axios.post<RegisterRequest, AxiosResponse<User>>(`${BASE_URL}${REGISTER_URL}`, request);
            dispatch(success(response.data));
        } catch (error) {
            const err = error as AxiosError<ErrorResponse>;
            await dispatch(failure())
            await dispatch(alertActions.error(err.response?.data.error ?? 'Login error.'));
        }

        function success(user: User): AuthAction {
            return {type: AuthTypes.REGISTER_SUCCESS, user}
        }

        function failure(): AuthAction {
            return {type: AuthTypes.REGISTER_FAILURE,  user: null}
        }
    }
}