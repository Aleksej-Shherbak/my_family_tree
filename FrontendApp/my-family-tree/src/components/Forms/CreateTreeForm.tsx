import React from 'react';
import {Formik, useFormik} from 'formik';
import * as yup from 'yup';
import {Button, Input, TextField} from "@mui/material";
import {useTheme} from "@mui/material/styles";
import IconButton from "@mui/material/IconButton";
import {PhotoCamera} from "@mui/icons-material";
import PreviewImage from "./PreviewImage";

const validationSchema = yup.object({
    title: yup
        .string()
        .required('Title is required'),
});

interface CreateTreeFormType {
    title: string,
    description?: string,
    image?: File
}

const CreateTreeForm = () => {
    const theme = useTheme();
    const initialValue: CreateTreeFormType = {
        title: 'My new family tree',
    };

    return (
        <Formik
            initialValues={initialValue}
            validationSchema={validationSchema}
            onSubmit={(values, {setSubmitting}) => {
                alert(JSON.stringify(values, null, 2));
                setSubmitting(false);
            }}
        >
            {({
                  values, isSubmitting,
                  errors,
                  touched,
                  handleChange,
                  setFieldValue
              }) => (
                <form>
                    {values.image && <PreviewImage file={values.image}/>}
                    <label htmlFor="icon-button-file">
                        <IconButton color="primary" aria-label="upload picture" component="span" sx={{
                            marginBottom: theme.spacing(2)
                        }}>
                            <PhotoCamera sx={{marginRight: theme.spacing(1)}}/> UPLOAD IMAGE
                        </IconButton>
                        <Input
                            name="image"
                            onChange={(e: React.ChangeEvent<HTMLInputElement>) => 
                                {setFieldValue('image', e.currentTarget.files?.item(0))}}
                            id="icon-button-file"
                            type="file"
                            sx={{
                                display: "none"
                            }}/>
                    </label>

                    <TextField
                        fullWidth
                        name="title"
                        label="Title"
                        type="text"
                        value={values.title}
                        error={touched.title && Boolean(errors.title)}
                        helperText={touched.title && errors.title}
                        onChange={handleChange}
                        sx={{
                            marginBottom: theme.spacing(2)
                        }}
                    />

                    <TextField
                        fullWidth
                        multiline
                        rows={5}
                        label="Description"
                        type="text"
                        value={values.description}
                        onChange={handleChange}
                        sx={{
                            marginBottom: theme.spacing(2)
                        }}
                    />
                    <Button color="primary" variant="contained" type="submit">
                        Submit
                    </Button>
                </form>
            )}
        </Formik>
    );
};


export default CreateTreeForm;