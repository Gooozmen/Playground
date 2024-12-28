using System.Text.Json.Nodes;

namespace Shared.Helpers;

public interface IJsonHelper
{
    public T ConvertJsonObjectToEntity<T>(JsonObject jsonObject);
}