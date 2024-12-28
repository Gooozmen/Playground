using Microsoft.Extensions.Options;
using Shared.Options;
using Shared.DTOs;
using System.Text.Json.Nodes;
using Shared.Helpers;
namespace Infrastructure.ApplicationHttpClient;
public class WeatherstackClient : HttpClientService, IWeatherstackClient
{
    private const string HttpClientName = "Weatherstack";
    private readonly IJsonHelper _jsonHelper;
    private readonly WeatherstackApi _weatherstack;

    public WeatherstackClient()
        : this(new DefaultHttpClientFactory(), Options.Create(new WeatherstackApi()), new JsonHelper())
    {
    }

    public WeatherstackClient(IHttpClientFactory httpClientFactory,
                              IOptions<WeatherstackApi> options,
                              IJsonHelper jsonHelper)
                              : base(httpClientFactory)
    {
        _weatherstack = options.Value ?? throw new ArgumentNullException(nameof(options));
        _jsonHelper = jsonHelper;
    }

    public async Task<JsonObject> GetWeatherAsync(string location)
    {
        // Example endpoint for Weatherstack API
        string baseUrl = _weatherstack.BaseUrl;
        string endpoint = $"/current?access_key={_weatherstack.Key}&query={location}";

        var response = await GetAsync<JsonObject>(baseUrl, endpoint, HttpClientName);

        return response;
    }
}

public class DefaultHttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateClient(string name) => new HttpClient();
}
