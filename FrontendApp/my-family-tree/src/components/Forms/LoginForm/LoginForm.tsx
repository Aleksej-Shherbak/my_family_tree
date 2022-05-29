import React, {useState} from 'react';
import {FormGroup, TextField} from "@mui/material";
import {useTheme} from "@mui/material/styles";

const LoginForm = () => {
    const theme = useTheme();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    
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
                       onChange={(e) => setEmail(e.target.value)}
                       
            />
            <TextField type="password"
                       placeholder="Enter password"
                       label="Password"
                       variant="outlined"
                       sx={{
                           paddingBottom: theme.spacing(2)
                       }}
                       onChange={(e) => setPassword(e.target.value)}
            />
        </FormGroup>
    );
};

export default LoginForm;