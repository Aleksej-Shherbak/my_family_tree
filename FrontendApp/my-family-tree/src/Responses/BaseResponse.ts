export interface BaseResponse<T> {
    data: T,
    message: string,
    isSuccess: boolean
}