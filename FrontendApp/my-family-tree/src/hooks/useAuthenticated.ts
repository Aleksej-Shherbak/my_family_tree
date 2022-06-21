import {useEffect} from "react";
import {useNavigate} from "react-router-dom";
import {getRoutePathByName, routeNames} from "../router/routes";
import {useSelector} from "react-redux";
import {IAppState} from "../redux/AppStateTypes";

export const useAuthenticated = () => {
    const user = useSelector<IAppState>((state ) => {
        return state.auth.user
    });
    const navigate = useNavigate();
    useEffect(() => {
        if (user === null) {
            return navigate(getRoutePathByName(routeNames.login));
        }
    }, [user]);
}