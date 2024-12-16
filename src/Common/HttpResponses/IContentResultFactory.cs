using Microsoft.AspNetCore.Mvc;

namespace Common.HttpResponses;

public interface IContentResultFactory<T> where T : class
{
    ContentResult Create<T>(ResponseBase<T> response);
    ContentResult Success<T>(T data, int statusCode = 200, string message = "Operation successful");
    ContentResult Error<T>(string message, int statusCode = 400);
}
