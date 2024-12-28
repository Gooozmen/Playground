using System.Net.Http.Json;

namespace Infrastructure.ApplicationHttpClient;

public abstract class HttpClientService
{
    private readonly IHttpClientFactory _httpClientFactory;

    protected HttpClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    protected async Task<T> GetAsync<T>(string baseUrl, string urlEndpoint, string httpClientName)
    {

        var client = _httpClientFactory.CreateClient(httpClientName);

        var uriBase = $"{baseUrl}{urlEndpoint}";

        var response = await client.GetAsync(uriBase);

        response.EnsureSuccessStatusCode();

        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            return (T)Activator.CreateInstance(typeof(T));

        var dataResponse = await response.Content.ReadFromJsonAsync<T>();

        return dataResponse!;
    }

    protected async Task<T> PostAsync<T, TU>(string urlEndpoint, TU tu, string httpClientName)
    {

        var client = _httpClientFactory.CreateClient(httpClientName);


        var uriBase = $"{client.BaseAddress}{urlEndpoint}";


        var response = await client.PostAsJsonAsync(uriBase, tu);

        response.EnsureSuccessStatusCode();

        var dataResponse = await response.Content.ReadFromJsonAsync<T>();

        return dataResponse!;
    }

    protected async Task<bool> PutAsync<T>(string urlEndpoint, T tu, string httpClientName)
    {

        var client = _httpClientFactory.CreateClient(httpClientName);


        var uriBase = $"{client.BaseAddress}{urlEndpoint}";


        var response = await client.PutAsJsonAsync(uriBase, tu);

        response.EnsureSuccessStatusCode();

        return true;
    }

    protected async Task<bool> PatchAsync(string urlEndpoint, string httpClientName)
    {

        var client = _httpClientFactory.CreateClient(httpClientName);


        var uriBase = $"{client.BaseAddress}{urlEndpoint}";


        var request = new HttpRequestMessage(HttpMethod.Patch, uriBase);

        var response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return true;
    }

    protected async Task<bool> DeleteAsync(string urlEndpoint, string httpClientName)
    {

        var client = _httpClientFactory.CreateClient(httpClientName);


        var uriBase = $"{client.BaseAddress}{urlEndpoint}";


        var response = await client.DeleteAsync(uriBase);

        response.EnsureSuccessStatusCode();

        return true;
    }
}
