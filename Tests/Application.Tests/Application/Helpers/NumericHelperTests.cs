using Application.Helpers;

namespace Tests.Application.Helpers;

public class NumericHelperTests
{
    private readonly NumericHelper _numericHelper;

    public NumericHelperTests()
    {
        _numericHelper = new NumericHelper();
    }

    [Theory]
    [InlineData(1,10)]
    [InlineData(2, 5)]
    [InlineData(5,15)]

    public void GenerateRandomNumberTests(int lowerBound, int upperBound)
    {
        // Act
        int result = _numericHelper.GenerateRandomNumber(lowerBound, upperBound);

        // Assert
        Assert.InRange(result, lowerBound, upperBound - 1);
    }
}
