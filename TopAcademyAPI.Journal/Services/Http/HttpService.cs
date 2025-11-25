namespace TopAcademyAPI.Journal.Services.Http;

public class HttpService(HttpClient httpClient)
{
    public async Task<TResponse> GetAsync<TResponse>(string endpoint)
    {
        return await ExecuteRequestAsync<TResponse>(() => httpClient.GetAsync(endpoint));
    }
    
    public async Task<TResponse> PostAsync<TResponse>(string endpoint)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        
        return await ExecuteRequestAsync<TResponse>(() => httpClient.SendAsync(request));
    }
    
    public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data) where TRequest : class
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = HttpJsonSerializer.Serialize(data)
        };
        
        return await ExecuteRequestAsync<TResponse>(() => httpClient.SendAsync(request));
    }
    
    private static async Task<TResponse> ExecuteRequestAsync<TResponse>(Func<Task<HttpResponseMessage>> action)
    {
        var response = await action();
        response.EnsureSuccessStatusCode();  

        return await HttpJsonSerializer.DeserializeAsync<TResponse>(response.Content);
    }
}