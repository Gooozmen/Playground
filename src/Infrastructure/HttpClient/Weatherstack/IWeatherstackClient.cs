namespace Infrastructure.HttpClient;

public interface IWeatherstackClient
{
    Task<WeatherstackResponse> GetWeatherAsync(string location);
}
