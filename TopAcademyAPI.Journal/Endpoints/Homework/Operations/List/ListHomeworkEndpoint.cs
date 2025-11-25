using TopAcademyAPI.Journal.Commands;

namespace TopAcademyAPI.Journal.Endpoints.Homework.Operations.List;

public static class ListHomeworkEndpoint
{
    public static async Task<List<ListHomeworkResponse>?> ListHomeworkAsync(JournalApi journalApi)
    {
        var action = journalApi.HttpService.GetAsync<List<ListHomeworkResponse>>(BaseEndpoints.ListHomeworkEndpoint);
        return await Command.ExecuteAsync(() => action, journalApi);
    }
}