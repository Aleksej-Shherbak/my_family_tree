import { AnyAction} from "redux";

export enum AlertTypes {
    SUCCESS = 1,
    ERROR,
    CLEAR
}  

export interface AlertAction  extends AnyAction {
    message: string|null
}