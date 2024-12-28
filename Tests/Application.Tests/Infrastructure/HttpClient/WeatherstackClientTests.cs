using System.Net;
using Shared.Options;
using Infrastructure.ApplicationHttpClient;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Shared.DTOs;
using Shared.Helpers;

namespace Tests.Infrastructure.ApplicationHttpClient;
public class WeatherstackClientTests
{
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private readonly Mock<IOptions<WeatherstackApi>> _optionsMock;
    private readonly Mock<IJsonHelper> _jsonHelper;
    private readonly WeatherstackApi _weatherstackApi;
    private readonly HttpClient _httpClient;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly WeatherstackClient _client;

   
}

