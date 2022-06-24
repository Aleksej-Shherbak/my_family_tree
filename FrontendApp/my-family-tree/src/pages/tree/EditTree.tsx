import React from 'react';
import MainLayout from "../../layouts/MainLayout/MainLayout";
import {Box, Typography} from "@mui/material";
import CreateTreeForm from "../../components/Forms/CreateTreeForm";

const EditTree = () => {
    return (
        <MainLayout>
            <Typography variant="h3" mt={2}>Create new family tree</Typography>
           <Box>
               <CreateTreeForm/>
           </Box>
        </MainLayout>
    );
};

export default EditTree;