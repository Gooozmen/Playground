using Application.Factories;
using Application.Responses;
using Domain.Options;
using Microsoft.Extensions.Options;

namespace Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IResponseFactory _responseFactory;
    private readonly Weatherstack _weatherstack;

    public WeatherService(IOptions<Weatherstack> options,
                          IResponseFactory responseFactory)
    {
        _weatherstack = options.Value;
        _responseFactory = responseFactory;
    }
    public ResponseBase<Weatherstack> Execute()
    {
        var weatherstack = _weatherstack;
        var emptyWeatherStack = new Weatherstack
        {
            BaseUrl = string.Empty,
            Key = string.Empty
        };

        return weatherstack switch
        {
            { BaseUrl: not null and not "", Key: not null and not "" } =>
                _responseFactory.Success(weatherstack),
            { BaseUrl: "", Key: "" } =>
                _responseFactory.Error("Binding Error: BaseUrl and Key are empty.", emptyWeatherStack),
            null =>
                _responseFactory.Error("Binding Error: Weatherstack is null.", emptyWeatherStack),
            _ =>
                _responseFactory.Error("Binding Error: Invalid Weatherstack configuration.", emptyWeatherStack),
        };

    }
}
