import {AlertAction, AlertTypes} from "./AlertTypes";

export const alertActions = {
    success,
    error,
    clear
};

function success(message: string): AlertAction {
    return { type: AlertTypes.ALERT_SUCCESS, message };
}

function error(message: string): AlertAction {
    return { type: AlertTypes.ALERT_ERROR, message };
}

function clear(): AlertAction {
    return { type: AlertTypes.ALERT_CLEAR, message: null };
}