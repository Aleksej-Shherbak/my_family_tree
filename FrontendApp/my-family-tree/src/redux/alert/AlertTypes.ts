import { AnyAction} from "redux";

export enum AlertTypes {
    ALERT_SUCCESS = 'ALERT_SUCCESS',
    ALERT_ERROR = 'ALERT_ERROR',
    ALERT_CLEAR = 'ALERT_CLEAR'
}  

export interface AlertAction  extends AnyAction {
    message: string|null
}