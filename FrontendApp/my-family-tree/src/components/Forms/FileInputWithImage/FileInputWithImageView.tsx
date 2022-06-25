import React, {useState} from 'react';
import IconButton from "@mui/material/IconButton";
import {PhotoCamera, Cancel} from "@mui/icons-material";
import {Box, Input} from "@mui/material";
import {useTheme} from "@mui/material/styles";
import {pink} from "@mui/material/colors";
import PreviewImage from "./PreviewImage";

interface FileInputWithImageViewProps {
    onChangeHandler(event: React.ChangeEvent<HTMLInputElement>|null): void
}

const FileInputWithImageView: React.FC<FileInputWithImageViewProps> = ({onChangeHandler}) => {
    const theme = useTheme();
    const [file, setFile] = useState<File|null>(null);
    
    const onChangeLocalHandler = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFile(e.currentTarget.files?.item(0) ?? null);
        onChangeHandler(e);
    }
    const removeImageHandler = () => {
        setFile(null);
        onChangeHandler(null);
    };
    
    return (
        <>
            {file && <Box sx={{
                border: 1,
                padding: 2,
                borderRadius: 1,
                borderColor: theme.palette.grey[500],
                position: 'relative',
                width: '200px',
                height: '200px',
                marginBottom: theme.spacing(2)
            }}>
                <IconButton 
                    color="primary" 
                    component="span" 
                    sx={{
                        position: 'absolute',
                        left: theme.spacing(18)
                    }}
                    onClick={removeImageHandler}
                >
                    <Cancel sx={{ color: pink[400], ":hover": { color: pink[700] } }}/>
                </IconButton>
                <PreviewImage file={file}/>
            </Box>}
            {!file && <label htmlFor="icon-button-file">
                <IconButton color="primary" aria-label="upload picture" component="span" sx={{
                    marginBottom: theme.spacing(2)
                }}>
                    <PhotoCamera sx={{marginRight: theme.spacing(1)}}/> UPLOAD IMAGE
                </IconButton>
                <Input
                    name="image"
                    onChange={onChangeLocalHandler}
                    id="icon-button-file"
                    type="file"
                    sx={{
                        display: "none"
                    }}/>
            </label>
            }    
        </>
    );
};

export default FileInputWithImageView;