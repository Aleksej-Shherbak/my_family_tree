import {AlertAction, AlertTypes} from "./AlertTypes";

export interface AlertState {
    message: string | null
}

const initialState: AlertState = {
    message: null
}

export const alertReducer = (state: AlertState = initialState, action: AlertAction): AlertState => {
    switch (action.type) {
        case AlertTypes.SUCCESS:
            return {
                message: action.message
            };
        case AlertTypes.ERROR:
            return {
                message: action.message
            };
        case AlertTypes.CLEAR:
            return {
                message: null
            };
    }
    return state
}

