namespace Shared.Helpers;

public class NumericHelper : INumericHelper
{
    public int GenerateRandomNumber(int lowerBound, int upperBound)
    {
        Random random = new Random();
        var result = random.Next(lowerBound, upperBound);
        return result;
    }
}
