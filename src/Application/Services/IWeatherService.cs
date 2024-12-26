using Domain.Options;
using Application.Responses;

namespace Application.Services;

public interface IWeatherService
{
    ResponseBase<Weatherstack> Execute();
}
