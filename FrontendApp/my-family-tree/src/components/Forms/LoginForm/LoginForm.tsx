import React, {useEffect, useState} from 'react';
import {Button, FormGroup, TextField} from "@mui/material";
import {useTheme} from "@mui/material/styles";
import validator from 'validator'
import {useDispatch, useSelector} from "react-redux";
import {LoginRequest} from "../../../Requests/Auth/LoginRequest";
import {authActions} from "../../../redux/auth/AuthActions";
import {AnyAction} from "redux";
import {AuthState} from "../../../redux/auth/AuthReducer";
import {ThunkDispatch} from "redux-thunk";
import {useNavigate} from "react-router-dom";
import {getRoutePathByName, routeNames} from "../../../router/routes";
import {IAppState} from "../../../redux/AppStateTypes";
import {AlertState} from "../../../redux/alert/AlertReducer";

const LoginForm = () => {
    const theme = useTheme();
    const [isEmailHasCorrectFormat, setIsEmailHasCorrectFormat] = useState<boolean | null>(null);
    const [isSubmitEnabled, setSubmitEnabled] = useState(false);
    const [loginRequest, setLoginRequest] = useState<LoginRequest>({
        email: '',
        password: ''
    });

    useEffect(() => {
        setSubmitAvailability(loginRequest);
    }, [loginRequest])

    const setSubmitAvailability = (request: LoginRequest) => {
        if (request.email && request.password && isEmailValid(request.email)) {
            setSubmitEnabled(true);
        } else {
            setSubmitEnabled(false);
        }
    }

    const isEmailValid = (email: string): boolean => {
        if (!validator.isEmail(email)) {
            setIsEmailHasCorrectFormat(false);
            return false;
        }
        setIsEmailHasCorrectFormat(true);
        return true;
    };
    
    const dispatch: ThunkDispatch<AuthState, any, AnyAction> = useDispatch();
    const authState = useSelector<IAppState, AuthState>((state) => {
        return state.auth
    });
    const alertState = useSelector<IAppState, AlertState>((state) => {
        return state.alert
    });
    
    const navigate = useNavigate();
    useEffect(() => {
        if (authState.user !== null) {
            navigate(getRoutePathByName(routeNames.home));
        }
    }, [authState.user])
    
    const handleSubmit = () => {
        return dispatch(authActions.login(loginRequest));
    }

    const handleOnKeyUp = async (e:  React.KeyboardEvent) => {
        if (e.key === 'Enter' && isSubmitEnabled) {
            return handleSubmit();
        }
    }

    return (
        <FormGroup sx={{
            width: theme.spacing(60)
        }}>
            <TextField type="email"
                       placeholder="Enter email"
                       label="Email"
                       variant="outlined"
                       sx={{
                           paddingBottom: theme.spacing(2)
                       }}
                       onChange={(e) => setLoginRequest({...loginRequest, email: e.target.value})}
                       required={true}
                       onBlur={(e) => isEmailValid(e.target.value)}
                       error={isEmailHasCorrectFormat === false || alertState.isError === true}
                       onKeyUp={handleOnKeyUp}

            />

            <TextField type="password"
                       placeholder="Enter password"
                       label="Password"
                       variant="outlined"
                       sx={{
                           paddingBottom: theme.spacing(2)
                       }}
                       onChange={(e) => setLoginRequest({...loginRequest, password: e.target.value})}
                       required={true}
                       error={alertState.isError === true}
                       onKeyUp={handleOnKeyUp}
            />
            
            <Button disabled={!isSubmitEnabled} onClick={handleSubmit} sx={{width: theme.spacing(10)}} variant="contained">Login</Button>
        </FormGroup>
    );
};

export default LoginForm;