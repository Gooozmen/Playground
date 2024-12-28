using Shared.Enums;

namespace Shared.Contracts.Responses;

public class ResponseBase<T>
{

    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public ResponseBase(int statusCode, T data, string message)
    {
        StatusCode = statusCode;
        IsSuccess = SetIsSuccess(statusCode);
        Message = message;
        Data = data;
    }
    public ResponseBase(int statusCode, T data)
    {
        StatusCode = statusCode;
        IsSuccess = SetIsSuccess(statusCode);
        Message = HttpStatusDescriptions.GetDescription(statusCode);
        Data = data;
    }

    public ResponseBase()
    {
    }

    private bool SetIsSuccess(int statusCode)
    {
        IsSuccess = statusCode switch
        {
            >= 200 and < 300 => true, // Success range
            _ => false               // Failure range
        };

        return IsSuccess;
    }

}