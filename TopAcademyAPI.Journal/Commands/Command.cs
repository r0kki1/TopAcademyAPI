using TopAcademyAPI.Journal.Exceptions;

namespace TopAcademyAPI.Journal.Commands;

public static class Command
{
    public static async Task<TResponse> ExecuteAsync<TResponse>(Func<Task<TResponse>> action, JournalApi journalApi,
        string? token = null, bool isSkipCheckAccessToken = false)
    {
        if (!isSkipCheckAccessToken && token == null)
        {
            throw new TokenIsNullException();
        }
        
        journalApi.AccessToken = token;
        
        return await action();
    }
    
}