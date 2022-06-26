import React from 'react';
import {ErrorMessage, Form, Formik} from 'formik';
import * as yup from 'yup';
import {Box, Button, TextField} from "@mui/material";
import {useTheme} from "@mui/material/styles";
import FileInputWithImageView from "./FileInputWithImage/FileInputWithImageView";
import {ThunkDispatch} from "redux-thunk";
import {AuthState} from "../../redux/auth/AuthReducer";
import {AnyAction} from "redux";
import {useDispatch} from "react-redux";
import {treeActions} from "../../redux/tree/TreeActions";
import {CreateTreeRequest} from "../../Requests/Tree/CreateTreeRequest";

const MAX_FILE_SIZE: number = 2_000_000;
const SUPPORTED_FORMATS: string[] = ['image/jpg', 'image/jpeg', 'image/png'];
const getSupportedFormatsString = (): string => SUPPORTED_FORMATS
    .map(x => x.replace('image/', '')).join(', ');

const validationSchema = yup.object({
    title: yup
        .string()
        .required('Title is required'),
    image: yup.mixed().test('fileSize', 'The file is too large! Please, try another one.', (value: File | null | undefined) => {
        if (!value) {
            return true;
        }
        return value.size < MAX_FILE_SIZE;
    }).test('type', `Only the following formats are accepted: ${getSupportedFormatsString()}`, (value: File | null | undefined) => {
        return !value || SUPPORTED_FORMATS.includes(value.type);
    })
});

const CreateTreeForm = () => {
    const dispatch: ThunkDispatch<AuthState, any, AnyAction> = useDispatch();
    const theme = useTheme();
    const initialValue: CreateTreeRequest = {
        title: 'My new family tree',
    };

    return (
        <Formik
            initialValues={initialValue}
            validationSchema={validationSchema}
            onSubmit={(values, {setSubmitting}) => {
                (async () => {
                    if (values !== null) {
                        await dispatch(treeActions.createTree(values))
                    }
                    setSubmitting(false);
                })()
            }}
        >
            {({
                  values,
                  isSubmitting,
                  errors,
                  touched,
                  handleChange,
                  setFieldValue,
                  handleBlur
              }) => (
                <Form>
                    <FileInputWithImageView
                        onChangeHandler={(e: React.ChangeEvent<HTMLInputElement> | null) => {
                            if (e === null) {
                                setFieldValue('image', null)
                                return;
                            }
                            setFieldValue('image', e.currentTarget.files?.item(0))
                        }}
                    />
                    <Box sx={{
                        marginBottom: theme.spacing(2),
                        color: theme.palette.error.dark
                    }}>
                        <ErrorMessage name="image" component="div"/>
                    </Box>

                    <TextField
                        fullWidth
                        name="title"
                        label="Title"
                        type="text"
                        value={values.title}
                        error={touched.title && Boolean(errors.title)}
                        helperText={touched.title && errors.title}
                        onChange={handleChange}
                        onBlur={handleBlur}
                        sx={{
                            marginBottom: theme.spacing(2)
                        }}
                    />

                    <TextField
                        fullWidth
                        multiline
                        name="description"
                        rows={5}
                        label="Description"
                        type="text"
                        value={values.description}
                        onChange={handleChange}
                        sx={{
                            marginBottom: theme.spacing(2)
                        }}
                    />
                    <Button color="primary" variant="contained" type="submit" disabled={isSubmitting}>
                        Submit
                    </Button>
                </Form>
            )}
        </Formik>
    );
};

export default CreateTreeForm;