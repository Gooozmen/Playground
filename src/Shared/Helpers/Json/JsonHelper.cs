using System.Text.Json.Nodes;
using System.Text.Json;

namespace Shared.Helpers;

public class JsonHelper : IJsonHelper
{
    public T ConvertJsonObjectToEntity<T>(JsonObject jsonObject)
    {
        string jsonString = jsonObject.ToJsonString();
        return JsonSerializer.Deserialize<T>(jsonString)!;
    }
}
