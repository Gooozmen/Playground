using Application.Contracts.Responses;

namespace Application.Factories;

public interface IResponseFactory
{
    // Método genérico para respuestas exitosas
    ResponseBase<T> Success<T>(T data, int statusCode = 200, string message = "Operation successful");

    // Método genérico para respuestas de error
    ResponseBase<T> Error<T>(string message, T data, int statusCode = 400);
}
