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

        
    }
}
