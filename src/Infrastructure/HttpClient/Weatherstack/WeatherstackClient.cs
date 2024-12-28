﻿using Microsoft.Extensions.Options;
using Shared.Options;
using Shared.DTOs;
namespace Infrastructure.ApplicationHttpClient;
public class WeatherstackClient : HttpClientService, IWeatherstackClient
{
    private const string HttpClientName = "Weatherstack";
    private readonly WeatherstackApi _weatherstack;

    public WeatherstackClient()
        : this(new DefaultHttpClientFactory(), Options.Create(new WeatherstackApi()))
    {
    }

    public WeatherstackClient(IHttpClientFactory httpClientFactory,
                              IOptions<WeatherstackApi> options)
                              : base(httpClientFactory)
    {
        _weatherstack = options.Value ?? throw new ArgumentNullException(nameof(options));
    }

    public async Task<WeatherstackResponse> GetWeatherAsync(string location)
    {
        // Example endpoint for Weatherstack API
        string endpoint = $"{_weatherstack.BaseUrl}/current?access_key={_weatherstack.Key}&query={location}";

        var response = await GetAsync<WeatherstackResponse>(endpoint, HttpClientName);

        if (response == null) 
            throw new Exception("Weatherstack request has failed");

        return response;
    }
    
}

public class DefaultHttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateClient(string name) => new HttpClient();
}
