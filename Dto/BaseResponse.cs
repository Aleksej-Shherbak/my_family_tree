namespace Dto;

public record BaseResponse<T>(bool IsSuccess, string Message, T Data);
