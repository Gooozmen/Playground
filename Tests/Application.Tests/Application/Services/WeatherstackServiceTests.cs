using Application.Contracts.Responses;
using Application.Factories;
using Application.Services;
using Infrastructure.ApplicationHttpClient;
using Moq;

namespace Application.Tests.Services
{
    public class WeatherServiceTests
    {
        private readonly Mock<IWeatherstackClient> _weatherstackClientMock;
        private readonly Mock<IResponseFactory> _responseFactoryMock;
        private readonly WeatherService _weatherService;

        public WeatherServiceTests()
        {
            _weatherstackClientMock = new Mock<IWeatherstackClient>();
            _responseFactoryMock = new Mock<IResponseFactory>();

            _weatherService = new WeatherService(_weatherstackClientMock.Object,_responseFactoryMock.Object);
        }

        [Fact]
        public async Task GetWeatherForLocation_ShouldReturnSuccessResponse()
        {
            // Arrange
            var location = "New York";
            var weatherstackResponse = new WeatherstackResponse(); // Assuming this is a valid instance
            var expectedResponse = new ResponseBase<WeatherstackResponse> { Data = weatherstackResponse };

            _weatherstackClientMock.Setup(x => x.GetWeatherAsync(location))
                .ReturnsAsync(weatherstackResponse);

            _responseFactoryMock.Setup(x => x.Success(weatherstackResponse,200,"Operation successful"))
                .Returns(expectedResponse);

            // Act
            var result = await _weatherService.GetWeatherForLocation(location);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse, result);
            _weatherstackClientMock.Verify(x => x.GetWeatherAsync(location), Times.Once);
            _responseFactoryMock.Verify(x => x.Success(weatherstackResponse, 200, "Operation successful"), Times.Once);
        }

        [Fact]
        public async Task GetWeatherForLocation_ShouldHandleClientFailureGracefully()
        {
            // Arrange
            var location = "Unknown";
            _weatherstackClientMock.Setup(x => x.GetWeatherAsync(location))
                .ThrowsAsync(new Exception("API error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _weatherService.GetWeatherForLocation(location));
            _weatherstackClientMock.Verify(x => x.GetWeatherAsync(location), Times.Once);
        }
    }
}
