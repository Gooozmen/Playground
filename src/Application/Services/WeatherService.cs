using Application.Factories;
using Infrastructure.ApplicationHttpClient;
using System.Text.Json.Nodes;
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

    public async Task<JsonObject> GetWeatherForLocation(string location)
    {
        var response = await _weatherstackClient.GetWeatherAsync(location);
        return response;
    }


    public bool ValidateJsonResponse(JsonObject json)
    {
        var contains = json.ContainsKey("success");
        return !contains;
    }
}
public interface IWeatherService
{
    Task<JsonObject> GetWeatherForLocation(string location);
    bool ValidateJsonResponse(JsonObject json);
}