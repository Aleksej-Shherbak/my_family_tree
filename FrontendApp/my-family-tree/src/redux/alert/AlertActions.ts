import {AlertAction, AlertTypes} from "./AlertTypes";

export const alertActions = {
    success,
    error,
    clear
};

function success(message: string): AlertAction {
    return { type: AlertTypes.SUCCESS, message };
}

function error(message: string): AlertAction {
    return { type: AlertTypes.ERROR, message };
}

function clear(): AlertAction {
    return { type: AlertTypes.CLEAR, message: null };
}