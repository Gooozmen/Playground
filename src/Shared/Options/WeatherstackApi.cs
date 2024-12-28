namespace Shared.Options;

//options design pattern
public class WeatherstackApi
{
    public string BaseUrl { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public WeatherstackApi(string baseUrl, string key)
    {
        BaseUrl = baseUrl;
        Key = key;
    }
    public WeatherstackApi()
    {
    }
}
