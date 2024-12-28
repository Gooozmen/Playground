using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Responses;

namespace Application.Factories;

public interface IResponseFactory
{   /// <summary>
    /// Provides Response creational logic for http response
    /// </summary>
    /// <typeparam name="T">Generic Entity</typeparam>
    /// <param name="data">Entity required to be added to response base message</param>
    /// <param name="statusCode">Http result status code</param>
    /// <param name="message">Custom message for response</param>
    /// <returns>ResponseBase object that contains response entity and http request information with http information</returns>
    ResponseBase<T> HandleResponse<T>(T data, int statusCode);
    ResponseBase<T> HandleResponse<T>(T data, int statusCode, string message);

}
