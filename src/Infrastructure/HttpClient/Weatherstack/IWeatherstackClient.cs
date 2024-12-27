namespace Infrastructure.ApplicationHttpClient;

public interface IWeatherstackClient
{
    Task<WeatherstackResponse> GetWeatherAsync(string location);
}
