import {useEffect} from "react";
import {useNavigate} from "react-router-dom";
import {getPathByName, routeNames} from "../router/routes";

export const useAuthenticated = () => {
    // todo move to state
    const isAuthenticated = false;
    let navigate = useNavigate();

    useEffect(() => {
        if (!isAuthenticated) {
            return navigate(getPathByName(routeNames.login));
        }
    }, [isAuthenticated]);
}