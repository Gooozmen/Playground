using Application.Factories;
using Application.Services;
using Infrastructure.ApplicationHttpClient;
using Moq;
using System.Text.Json.Nodes;

namespace Application.Tests.Services;

public class WeatherServiceTests
{
    private readonly Mock<IWeatherstackClient> _weatherstackClientMock;
    private readonly Mock<IResponseFactory> _responseFactoryMock;
    private readonly WeatherService _weatherService;

    public WeatherServiceTests()
    {
        _weatherstackClientMock = new Mock<IWeatherstackClient>();
        _responseFactoryMock = new Mock<IResponseFactory>();
        _weatherService = new WeatherService(_weatherstackClientMock.Object, _responseFactoryMock.Object);
    }

    [Fact]
    public async Task GetWeatherForLocation_ShouldReturnJsonObject()
    {
        // Arrange
        var location = "New York";
        var mockJsonResponse = new JsonObject
        {
            ["location"] = "New York",
            ["temperature"] = "22",
            ["success"] = true
        };

        _weatherstackClientMock
            .Setup(client => client.GetWeatherAsync(location))
            .ReturnsAsync(mockJsonResponse);

        // Act
        var result = await _weatherService.GetWeatherForLocation(location);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.ContainsKey("location"));
        Assert.Equal("New York", result["location"].ToString());
        _weatherstackClientMock.Verify(client => client.GetWeatherAsync(location), Times.Once);
    }

    [Fact]
    public void ValidateJsonResponse_ShouldReturnTrue_WhenSuccessKeyIsNotPresent()
    {
        // Arrange
        var mockJsonResponse = new JsonObject
        {
            ["location"] = "New York",
            ["temperature"] = "22"
        };

        // Act
        var result = _weatherService.ValidateJsonResponse(mockJsonResponse);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateJsonResponse_ShouldReturnFalse_WhenSuccessKeyIsPresent()
    {
        // Arrange
        var mockJsonResponse = new JsonObject
        {
            ["success"] = true,
            ["location"] = "New York",
            ["temperature"] = "22"
        };

        // Act
        var result = _weatherService.ValidateJsonResponse(mockJsonResponse);

        // Assert
        Assert.False(result);
    }
}

