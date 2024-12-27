using System.Net;
using Domain.Options;
using Infrastructure.ApplicationHttpClient;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace Tests.Infrastructure.ApplicationHttpClient;
public class WeatherstackClientTests
{
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private readonly Mock<IOptions<WeatherstackApi>> _optionsMock;
    private readonly WeatherstackApi _weatherstackApi;
    private readonly HttpClient _httpClient;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly WeatherstackClient _client;

    public WeatherstackClientTests()
    {
        // Mock WeatherstackApi configuration
        _weatherstackApi = new WeatherstackApi
        {
            BaseUrl = "http://api.weatherstack.com",
            Key = "test_key"
        };
        _optionsMock = new Mock<IOptions<WeatherstackApi>>();
        _optionsMock.Setup(o => o.Value).Returns(_weatherstackApi);

        // Mock HTTP message handler
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object);

        // Mock IHttpClientFactory
        _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        _httpClientFactoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(_httpClient);

        // Create WeatherstackClient
        _client = new WeatherstackClient(_httpClientFactoryMock.Object, _optionsMock.Object);
    }

    [Fact]
    public async Task GetWeatherAsync_ShouldReturnWeatherstackResponse()
    {
        // Arrange
        var location = "New York";
        var expectedResponse = new WeatherstackResponse { Location = new WeatherstackLocation { Name = location } };
        var jsonResponse = "{ \"location\": { \"name\": \"New York\" } }";

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonResponse)
            });

        // Act
        var result = await _client.GetWeatherAsync(location);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(location, result.Location.Name);

        _httpMessageHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Get &&
                req.RequestUri.ToString().Contains($"current?access_key=test_key&query={location}")
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public async Task GetWeatherAsync_ShouldThrowExceptionForErrorResponse()
    {
        // Arrange
        var location = "InvalidLocation";

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("{ \"error\": \"Invalid request\" }")
            });

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetWeatherAsync(location));
    }
}

