using Shared.Contracts.Responses;
using Shared.Enums;

namespace Application.Factories;

/// <summary>
/// Factory to generate standardized API responses as ResponseBase<T>.
/// </summary>
/// <typeparam name="T">The type of the response data.</typeparam>
public class ResponseFactory : IResponseFactory
{
    public ResponseBase<T> HandleResponse<T>(T data, int statusCode, string message)
    {
        return new ResponseBase<T>(statusCode, data, message);
    }
    public ResponseBase<T> HandleResponse<T>(T data, int statusCode)
    {
        return new ResponseBase<T>(statusCode, data);
    }

}
