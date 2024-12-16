using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Common.HttpResponses;

public class ContentResultFactory : IContentResultFactory<ResponseBase> 
{
    public ContentResult Create<T>(ResponseBase<T> response)
    {
        throw new NotImplementedException();
    }

    public ContentResult Error<T>(string message, int statusCode = 400)
    {
        throw new NotImplementedException();
    }

    public ContentResult Success<T>(T data, int statusCode = 200, string message = "Operation successful")
    {
        throw new NotImplementedException();
    }
}

public static ContentResult Create<T>(ResponseBase<T> response)
{
    return new ContentResult
    {
        StatusCode = response.StatusCode,
        Content = System.Text.Json.JsonSerializer.Serialize(response),
        ContentType = "application/json"
    };
}

public static ContentResult Success<T>(T data, int statusCode = 200, string message = "Operation successful")
{
    var response = new ResponseBase<T>(statusCode, true, message, data);
    return Create(response);
}

public static ContentResult Error<T>(string message, int statusCode = 400)
{
    var response = new ResponseBase<T>(statusCode, false, message, default);
    return Create(response);
}
