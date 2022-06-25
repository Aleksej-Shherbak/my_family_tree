import React from 'react';
import MainLayout from "../../layouts/MainLayout/MainLayout";
import {Container, Typography} from "@mui/material";
import CreateTreeForm from "../../components/Forms/CreateTreeForm";
import {useTheme} from "@mui/material/styles";

const EditTree = () => {
    const theme = useTheme();
    return (
        <MainLayout>
            <Typography variant="h3" sx={{ marginBottom: theme.spacing(4) }} textAlign="center" mt={2}>Create new family tree</Typography>
           <Container>
               <CreateTreeForm/>
           </Container>
        </MainLayout>
    );
};

export default EditTree;