namespace Common.Helpers;

public static class NumericHelper
{
    public static int GenerateRandomNumber(int lowerBound, int upperBound)
    {
        Random random = new Random();
        var result = random.Next(lowerBound, upperBound);
        return result;
    }
}
