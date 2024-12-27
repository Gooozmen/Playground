using Application.Factories;

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
        var expectedMessage = "Operation successful";

        // Act
        var result = _responseFactory.Success(data);

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
        var customMessage = "Custom success message";

        // Act
        var result = _responseFactory.Success(data, customStatusCode, customMessage);

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
        var expectedMessage = "Error occurred";

        // Act
        var result = _responseFactory.Error(expectedMessage, data);

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
        var customStatusCode = 500;
        var customMessage = "Internal Server Error";

        // Act
        var result = _responseFactory.Error(customMessage, data, customStatusCode);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(customStatusCode, result.StatusCode);
        Assert.False(result.IsSuccess);
        Assert.Equal(customMessage, result.Message);
        Assert.Equal(data, result.Data);
    }
}
