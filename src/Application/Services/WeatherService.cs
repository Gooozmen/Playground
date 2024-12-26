using Application.Contracts.Responses;
using Application.Factories;
using Domain.Options;
using Infrastructure.HttpClient;

namespace Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IResponseFactory _responseFactory;
    private readonly IWeatherstackClient _weatherstackClient;

    public WeatherService(IWeatherstackClient weatherstackClient,
                          IResponseFactory responseFactory)
    {
        _responseFactory = responseFactory;
        _weatherstackClient = weatherstackClient;
    }

    public async Task<ResponseBase<WeatherstackResponse>> GetWeatherForLocation(string location)
    {
        var request = await _weatherstackClient.GetWeatherAsync(location);
        var result = _responseFactory.Success(request);
        return result;
    }
}

//var weatherstack = _weatherstack;
//var emptyWeatherStack = new Weatherstack
//{
//    BaseUrl = string.Empty,
//    Key = string.Empty
//};

//        return weatherstack switch
//        {
//            { BaseUrl: not null and not "",Key: not null and not "" } =>_responseFactory.Success(weatherstack),
//            { BaseUrl: "", Key: "" } =>_responseFactory.Error("Binding Error: BaseUrl and Key are empty.", emptyWeatherStack),
//            is null =>_responseFactory.Error("Binding Error: Weatherstack is null.", emptyWeatherStack),
//            _ => _responseFactory.Error("Binding Error: Invalid Weatherstack configuration.", emptyWeatherStack),
//        };