using Shared.Contracts.Responses;
using Application.Factories;
using Application.Services;
using Infrastructure.ApplicationHttpClient;
using Moq;
using Shared.DTOs;
using Shared.Enums;
using System.Net;

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
            #region Mock WeatherstackResponse
            var mockWeatherstackResponse = new WeatherstackResponse
            {
                Request = new WeatherstackRequest
                {
                    Type = "City",
                    Query = "New Delhi, India",
                    Language = "en",
                    Unit = "m"
                },
                Location = new WeatherstackLocation
                {
                    Name = "New Delhi",
                    Country = "India",
                    Region = "Delhi",
                    Lat = "28.600",
                    Lon = "77.200",
                    TimezoneId = "Asia/Kolkata",
                    Localtime = "2024-12-26 12:40",
                    LocaltimeEpoch = 1735216800,
                    UtcOffset = "5.50"
                },
                Current = new WeatherstackCurrent
                {
                    ObservationTime = "07:10 AM",
                    Temperature = 22,
                    WeatherCode = 113,
                    WeatherIcons = new List<string>
                    {
                        "https://cdn.worldweatheronline.com/images/wsymbols01_png_64/wsymbol_0001_sunny.png"
                    },
                    WeatherDescriptions = new List<string>
                    {
                        "Sunny"
                    },
                    WindSpeed = 5,
                    WindDegree = 47,
                    WindDir = "NE",
                    Pressure = 1021,
                    Precip = 0.0,
                    Humidity = 34,
                    Cloudcover = 3,
                    Feelslike = 24,
                    UvIndex = 4,
                    Visibility = 10,
                    IsDay = "yes"
                }
            };
            #endregion

            // Arrange
            var location = "New Delhi";
            var httpStatusDescription = HttpStatusDescriptions.GetDescription((int)HttpStatusCode.OK);
            var expectedResponse = new ResponseBase<WeatherstackResponse>
            {
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                Message = httpStatusDescription,
                Data = mockWeatherstackResponse
            };

            _weatherstackClientMock.Setup(x => x.GetWeatherAsync(location))
                .ReturnsAsync(mockWeatherstackResponse);

            _responseFactoryMock.Setup(x => x.HandleResponse(mockWeatherstackResponse, (int)HttpStatusCode.OK, httpStatusDescription))
                .Returns(expectedResponse);

            // Act
            var result = await _weatherService.GetWeatherForLocation(location);

            // Assert
            Assert.NotNull(result); // Ensure the response is not null
            Assert.Equal(expectedResponse.IsSuccess, result.IsSuccess); // Verify IsSuccess
            Assert.Equal(expectedResponse.StatusCode, result.StatusCode); // Verify StatusCode
            Assert.Equal(expectedResponse.Message, result.Message); // Verify Message
            Assert.Equal(expectedResponse.Data, result.Data); // Verify Data integrity

            // Verify mocks
            _weatherstackClientMock.Verify(x => x.GetWeatherAsync(location), Times.Once);
            _responseFactoryMock.Verify(x => x.HandleResponse(mockWeatherstackResponse, (int)HttpStatusCode.OK, httpStatusDescription), Times.Once);
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
