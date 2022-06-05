import {Action} from "redux";
import {AuthenticatedEnum} from "./types";

export interface AuthenticatedAction extends Action<AuthenticatedEnum>{
}

export const setAuth = () : AuthenticatedAction => {
    return {
      type: AuthenticatedEnum.Authorized  
    };
}

export const unsetAuth = () : AuthenticatedAction => {
    return {
        type: AuthenticatedEnum.NotAuthorized
    };
}