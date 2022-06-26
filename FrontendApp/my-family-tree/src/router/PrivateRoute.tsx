import {Navigate} from "react-router-dom";
import {getRoutePathByName, routeNames} from "./routes";
import {useSelector} from "react-redux";
import {IAppState} from "../redux/AppStateTypes";
import React from "react";

export interface ProtectedRouteProps {
    outlet: JSX.Element;
}

const PrivateRoute: React.FC<ProtectedRouteProps> = ({outlet}) => {
    const user = useSelector<IAppState>((state) => {
        return state.auth.user
    });
    if (user) {
        return outlet;
    } else {
        return <Navigate to={{pathname: getRoutePathByName(routeNames.login)}}/>;
    }
};

export default PrivateRoute;