import React, {useState} from 'react';

interface PreviewImageProps {
    file: File
}

const PreviewImage: React.FC<PreviewImageProps> = ({ file }) => {
    const [preview, setPreview] = useState<string | null>(null);
 
    const fileReader = new FileReader();
    fileReader.readAsDataURL(file);
    fileReader.onload = () => {
        if (fileReader.result) {
            setPreview(fileReader.result as string);
        }
    };
    return (
        <div>
            {preview && <img src={preview} alt="preview" width="200px" height="200px"/>}
        </div>
    );
};

export default PreviewImage;