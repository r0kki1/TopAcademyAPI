using System.Net.Http.Json;
using System.Text.Json;

namespace TopAcademyAPI.Journal.Services.Http;

public static class HttpJsonSerializer
{
    public static HttpContent Serialize<TRequest>(TRequest data)
    {
        try
        {
            return JsonContent.Create(data); 
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("result не должно быть null.");
        }
    }
    
    public static async Task<TResponse> DeserializeAsync<TResponse>(HttpContent content)
    {
        var json = await content.ReadAsStringAsync();
        try
        {
            return JsonSerializer.Deserialize<TResponse>(json) ?? throw new InvalidOperationException("result не должно быть null.");;
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("result не должно быть null.");
        }
        catch (JsonException ex)
        {
            throw new JsonException($"{json}", ex);
        }
    }
}