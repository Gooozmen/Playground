namespace Application.Contracts.Responses;

public class ResponseBase<T>
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public ResponseBase(int statusCode, bool isSuccess, string message, T data)
    {
        StatusCode = statusCode;
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }

    public ResponseBase(int statusCode, T data)
    {
        StatusCode = statusCode;
        IsSuccess = false;
        Message = string.Empty;
        Data = default;
    }

    public ResponseBase()
    {
    }

}