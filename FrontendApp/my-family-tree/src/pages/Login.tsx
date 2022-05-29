import React from 'react';
import NotAuthorizedLayout from "../layouts/NotAuthorizedLayout/NotAuthorizedLayout";
import LoginForm from "../components/Forms/LoginForm/LoginForm";

const Login = () => {
    return (
        <NotAuthorizedLayout>
            <LoginForm/>
        </NotAuthorizedLayout>
    );
};

export default Login;