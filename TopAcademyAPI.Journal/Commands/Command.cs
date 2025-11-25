namespace TopAcademyAPI.Journal.Commands;

public static class Command
{
    public static async Task<TResponse> ExecuteAsync<TResponse>(Func<Task<TResponse>> action, JournalApi journalApi,
        string? token = null)
    {
        journalApi.AccessToken = token;
        
        return await action();
    }
    
}