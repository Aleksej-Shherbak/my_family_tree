import {FILE_STORAGE_URL} from "../constants/backend";

export const getFileUrl = (fileName: string) => `${FILE_STORAGE_URL}/${fileName}`;  