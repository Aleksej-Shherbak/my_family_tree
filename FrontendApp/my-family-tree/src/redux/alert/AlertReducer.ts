import {AlertAction, AlertTypes} from "./AlertTypes";

export interface AlertState {
    message: string|null,
    isError: boolean|null
}

const initialState: AlertState = {
    message: null,
    isError: null
}

export const alertReducer = (state: AlertState = initialState, action: AlertAction): AlertState => {
    switch (action.type) {
        case AlertTypes.ALERT_SUCCESS:
            return {
                message: action.message,
                isError: false
            };
        case AlertTypes.ALERT_ERROR:
            return {
                message: action.message,
                isError: true
            };
        case AlertTypes.ALERT_CLEAR:
            return {
                message: null,
                isError: null
            };
    }
    return state
}

