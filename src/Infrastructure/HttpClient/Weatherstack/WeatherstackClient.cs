using Microsoft.Extensions.Options;
using Domain.Options;
namespace Infrastructure.HttpClient;
public class WeatherstackClient : HttpClientService, IWeatherstackClient
{
    private const string HttpClientName = "Weatherstack";
    private readonly Weatherstack _weatherstack;

    public WeatherstackClient(IHttpClientFactory httpClientFactory,
                              IOptions<Weatherstack> options)
                              : base(httpClientFactory)
    {
        _weatherstack = options.Value;
    }

    public async Task<WeatherstackResponse> GetWeatherAsync(string location)
    {
        // Example endpoint for Weatherstack API
        string endpoint = $"{_weatherstack.BaseUrl}/current?access_key={_weatherstack.Key}&query={location}";

        return await GetAsync<WeatherstackResponse>(endpoint, HttpClientName);
    }
    
}
