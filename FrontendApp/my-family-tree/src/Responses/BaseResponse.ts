// We use this mode if we need to know whether work of a service was successful or not and if it wasn't 
// what was the error. This is about business error, not unhandled exceptions, not something unexpected.
export interface BaseResponse<T> {
    isSuccess: boolean,
    message?: string
    data: T
}