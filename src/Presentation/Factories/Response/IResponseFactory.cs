using Presentation.Responses;

namespace Presentation.Factories;

public interface IResponseFactory<T> where T : class
{
    public ResponseBase<T> Success(T data, int statusCode = 200, string message = "Operation successful");
    public ResponseBase<T> Error(string message, T data, int statusCode = 400);
}
