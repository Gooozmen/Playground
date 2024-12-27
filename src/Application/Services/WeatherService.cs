using Application.Contracts.Responses;
using Application.Factories;
using Infrastructure.ApplicationHttpClient;

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
        var request = await _weatherstackClient.GetWeatherAsync(location);
        var result = _responseFactory.Success(request);
        return result;
    }
}