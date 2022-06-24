import React from 'react';
import {useFormik} from 'formik';
import * as yup from 'yup';
import {Button, TextField} from "@mui/material";

const validationSchema = yup.object({
    title: yup
        .string()
        .required('Title is required'),
});

interface CreateTreeFormType {
    title: string,
    description?: string
}

const CreateTreeForm = () => {
    const formik = useFormik<CreateTreeFormType>({
        initialValues: {
            title: 'My new family tree',
        },
        validationSchema: validationSchema,
        onSubmit: (values) => {
            console.log(JSON.stringify(values, null, 2));
        },
    });

    return (
        <div>
            <form onSubmit={formik.handleSubmit}>
                <TextField
                    fullWidth
                    name="title"
                    label="Title"
                    type="text"
                    value={formik.values.title}
                    onChange={formik.handleChange}
                    error={formik.touched.title && Boolean(formik.errors.title)}
                    helperText={formik.touched.title && formik.errors.title}
                />
                <TextField
                    fullWidth
                    label="Description"
                    type="text"
                    value={formik.values.description}
                    onChange={formik.handleChange}
                />
                <Button color="primary" variant="contained" fullWidth type="submit">
                    Submit
                </Button>
            </form>
        </div>
    );
};


export default CreateTreeForm;