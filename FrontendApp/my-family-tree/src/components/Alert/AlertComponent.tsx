import React, {useEffect} from 'react';
import {useSelector} from "react-redux";
import {IAppState} from "../../redux/AppStateTypes";
import {AlertState} from "../../redux/alert/AlertReducer";
import {Alert, Box, Collapse, IconButton} from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';

const AlertComponent: React.FC = () => {
    const alertState = useSelector<IAppState, AlertState>((state) => state.alert);
    const [open, setOpen] = React.useState(true);

    useEffect(() => {
        setOpen(true);
    }, [alertState])
    
    if (!alertState.message) {
        return (<></>);
    }

    const severity = alertState.isError === true ? "error" : "success";
    return (
        <Box sx={{ width: '100%' }}>
            <Collapse in={open}>
                <Alert
                    action={
                        <IconButton
                            aria-label="close"
                            color="inherit"
                            size="small"
                            onClick={() => {
                                setOpen(false);
                            }}
                        >
                            <CloseIcon fontSize="inherit" />
                        </IconButton>
                    }
                    sx={{ mb: 2, fontSize: "largest" }}
                    severity={severity}
                >
                    <strong>
                        {alertState.message}
                    </strong>
                </Alert>
            </Collapse>
        </Box>
    );
};

export default AlertComponent;