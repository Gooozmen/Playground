using Shared.Contracts.Responses;
using Shared.DTOs;
using Application.Factories;
using Infrastructure.ApplicationHttpClient;
using System.Net;
using Shared.Enums;
namespace Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IResponseFactory _responseFactory;
    private readonly IWeatherstackClient _weatherstackClient;
    public WeatherService()
    {
        _responseFactory = new ResponseFactory();
        _weatherstackClient = new WeatherstackClient();
    }

    public WeatherService(IWeatherstackClient weatherstackClient,
                          IResponseFactory responseFactory)
    {
        _responseFactory = responseFactory;
        _weatherstackClient = weatherstackClient;
    }

    public async Task<ResponseBase<WeatherstackResponse>> GetWeatherForLocation(string location)
    {
        var response = await _weatherstackClient.GetWeatherAsync(location);
        var result = _responseFactory.HandleResponse(response,(int)HttpStatus.OK);
        return result;
    }
}