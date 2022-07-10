import axios, {AxiosError, AxiosResponse, Method} from "axios";
import {BASE_URL} from "../../constants/backend";
import {authActions} from "../../redux/auth/AuthActions";
import {store} from "../../redux/RootReducer";
import {ErrorResponse} from "../../Responses/ErrorResponse";

export const MakeRequest = async <T = any, R = AxiosResponse<T>, D = any>(url: string, requestMethod: Method, data?: D): Promise<R | null> => {
    try {
        return await axios.request<T, R>({
            url: url,
            withCredentials: true,
            method: requestMethod,
            data: data,
            baseURL: BASE_URL
        })
    } catch (error) {
        const err = error as AxiosError<ErrorResponse>;
        if (err.response?.status === 401) {
            store.dispatch(authActions.eraseUserData());
            return null;
        }
        throw error;
    }
}
