using System.Text.Json.Nodes;

namespace Infrastructure.ApplicationHttpClient;

public interface IWeatherstackClient
{
    Task<JsonObject> GetWeatherAsync(string location);
}
