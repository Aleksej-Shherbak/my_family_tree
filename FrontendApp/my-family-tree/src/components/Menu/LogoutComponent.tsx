import React from 'react';
import {useDispatch} from "react-redux";
import {useNavigate} from "react-router-dom";
import {ThunkDispatch} from "redux-thunk";
import {AnyAction} from "redux";
import MenuItem from "./MenuItem";
import {authActions} from '../../redux/auth/AuthActions';
import {getRoutePathByName, routeNames} from '../../router/routes';
import ExitToAppIcon from '@mui/icons-material/ExitToApp';

interface LogoutComponentProps {
    isOpen: boolean
}

const LogoutComponent: React.FC<LogoutComponentProps> = (props) => {
    const dispatch: ThunkDispatch<{}, {}, AnyAction> = useDispatch();
    const navigate = useNavigate();

    const logoutCallback = function () {
        dispatch(authActions.logout()).then(() => {
            navigate(getRoutePathByName(routeNames.login));
        });
    };
    return (<MenuItem icon={ExitToAppIcon} isOpen={props.isOpen} title="Logout" callback={logoutCallback}/>);
};

export default LogoutComponent;