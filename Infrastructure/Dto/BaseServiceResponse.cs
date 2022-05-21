namespace Infrastructure.Dto;

public class BaseServiceResponse<T>
{
    public BaseServiceResponse(T data, bool isSuccess = true, string? message = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }

    public bool IsSuccess { get; }
    public string? Message { get; }
    public T Data { get; }
}