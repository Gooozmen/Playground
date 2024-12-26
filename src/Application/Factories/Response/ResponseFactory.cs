using Application.Responses;

namespace Application.Factories;

/// <summary>
/// Factory to generate standardized API responses as ResponseBase<T>.
/// </summary>
/// <typeparam name="T">The type of the response data.</typeparam>
public class ResponseFactory : IResponseFactory
{
    /// <summary>
    /// Creates a success response with the provided data.
    /// </summary>
    public ResponseBase<T> Success<T>(T data, int statusCode = 200, string message = "Operation successful")
    {
        return new ResponseBase<T>(statusCode, true, message, data);
    }
    /// <summary>
    /// Creates an error response with a message and optional status code.
    /// </summary>
    public ResponseBase<T> Error<T>(string message, T data, int statusCode = 400)
    {
        return new ResponseBase<T>(statusCode, false, message, data);
    }
}
