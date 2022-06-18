import React from 'react';
import {useSelector} from "react-redux";
import {IAppState} from "../../redux/AppStateTypes";
import {AlertState} from "../../redux/alert/AlertReducer";
import {Alert} from "@mui/material";

const AlertComponent: React.FC = () => {
    const alertState = useSelector<IAppState, AlertState>((state) => state.alert);
    
    if (!alertState.message) {
        return (<></>);
    }
    
    if (alertState.isError) {
        return (
            <Alert severity="error">{alertState.message}</Alert>
        );    
    } else {
        return (
            <Alert severity="success">{alertState.message}</Alert>
        );
    }
};

export default AlertComponent;