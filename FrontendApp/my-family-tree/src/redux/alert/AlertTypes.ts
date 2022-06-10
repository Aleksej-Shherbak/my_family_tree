import {Action} from "redux";

export enum AlertTypes {
    SUCCESS = 1,
    ERROR,
    CLEAR
}  

export interface AlertAction  extends Action<AlertTypes> {
    message: string|null
}