using Application.Factories;
using Shared.Enums;
using Xunit.Abstractions;

namespace Tests.Application.Factories;

public class ResponseFactoryTests
{
    private readonly ResponseFactory _responseFactory;

    public ResponseFactoryTests()
    {
        _responseFactory = new ResponseFactory();
    }

    [Fact]
    public void Success_ShouldReturnSuccessResponse()
    {
        // Arrange
        var data = "Test Data";
        var expectedStatusCode = 200;
        var expectedMessage = "OK";

        // Act
        var result = _responseFactory.HandleResponse(data,(int)HttpStatus.OK);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedStatusCode, result.StatusCode);
        Assert.True(result.IsSuccess);
        Assert.Equal(expectedMessage, result.Message);
        Assert.Equal(data, result.Data);
    }

    [Fact]
    public void Success_ShouldAllowCustomMessageAndStatusCode()
    {
        // Arrange
        var data = "Custom Data";
        var customStatusCode = 201;
        var customMessage = "Custom message";

        // Act
        var result = _responseFactory.HandleResponse(data, (int)HttpStatus.Created,"Custom message");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(customStatusCode, result.StatusCode);
        Assert.True(result.IsSuccess);
        Assert.Equal(customMessage, result.Message);
        Assert.Equal(data, result.Data);
    }

    [Fact]
    public void Error_ShouldReturnErrorResponse()
    {
        // Arrange
        var data = "Error Data";
        var expectedStatusCode = 400;
        var expectedMessage = "Bad Request";

        // Act
        var result = _responseFactory.HandleResponse(data,(int)HttpStatus.BadRequest);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedStatusCode, result.StatusCode);
        Assert.False(result.IsSuccess);
        Assert.Equal(expectedMessage, result.Message);
        Assert.Equal(data, result.Data);
    }

    [Fact]
    public void Error_ShouldAllowCustomStatusCode()
    {
        // Arrange
        var data = "Custom Error Data";
        var customStatusCode = 503;
        var customMessage = "Custom Internal Server Error";

        // Act
        var result = _responseFactory.HandleResponse(data, 503, "Custom Internal Server Error");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(customStatusCode, result.StatusCode);
        Assert.False(result.IsSuccess);
        Assert.Equal(customMessage, result.Message);
        Assert.Equal(data, result.Data);
    }
}
