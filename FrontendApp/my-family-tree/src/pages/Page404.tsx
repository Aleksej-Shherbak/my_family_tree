import React from 'react';
import NotAuthorizedLayout from "../layouts/NotAuthorizedLayout/NotAuthorizedLayout";
import {Typography} from "@mui/material";

const Page404 = () => {
    return (
        <NotAuthorizedLayout>
            <Typography variant="h3">Page not found ;(</Typography>
        </NotAuthorizedLayout>
    );
};

export default Page404;