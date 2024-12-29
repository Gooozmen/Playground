using Infrastructure.ApplicationHttpClient;
using Microsoft.Extensions.Options;
using Moq;
using Shared.Helpers;
using Shared.Options;
using System.Net;
using System.Text.Json.Nodes;

namespace Tests.Infrastructure.Client;

public class WeatherstackClientTests
{
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private readonly Mock<IJsonHelper> _jsonHelperMock;
    private readonly IOptions<WeatherstackApi> _options;
    private readonly WeatherstackClient _client;

    public WeatherstackClientTests()
    {
        _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        _jsonHelperMock = new Mock<IJsonHelper>();
        _options = Options.Create(new WeatherstackApi
        {
            BaseUrl = "https://api.weatherstack.com",
            Key = "test_key"
        });

        var mockHttpClient = new HttpClient(new FakeHttpMessageHandler())
        {
            BaseAddress = new Uri("https://api.weatherstack.com")
        };

        _httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                              .Returns(mockHttpClient);

        _client = new WeatherstackClient(
            _httpClientFactoryMock.Object,
            _options,
            _jsonHelperMock.Object
        );
    }

    [Fact]
    public async Task GetWeatherAsync_ShouldReturnJsonObject()
    {
        // Arrange
        var location = "New York";

        // Act
        var result = await _client.GetWeatherAsync(location);

        // Assert
        Assert.NotNull(result);
        Assert.True(result["success"]!.GetValue<bool>());
        Assert.Equal(location, result["location"]!["name"]!.GetValue<string>());
    }
}

public class FakeHttpMessageHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var jsonResponse = new JsonObject
        {
            ["success"] = true,
            ["location"] = new JsonObject
            {
                ["name"] = "New York"
            }
        }.ToJsonString();

        return Task.FromResult(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(jsonResponse)
        });
    }
}


