using TopAcademyAPI.Journal.Commands;

namespace TopAcademyAPI.Journal.Endpoints.Count.Homework;

public static class HomeworkEndpoint
{
    public static async Task<List<HomeworkResponse>?> HomeworkAsync(JournalApi journalApi)
    {
        var action = journalApi.HttpService.GetAsync<List<HomeworkResponse>>(BaseEndpoints.HomeworkEndpoint);
        return await Command.ExecuteAsync(() => action, journalApi);
    }
}