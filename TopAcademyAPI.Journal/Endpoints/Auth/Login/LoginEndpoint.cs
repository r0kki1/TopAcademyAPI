using TopAcademyAPI.Journal.Commands;

namespace TopAcademyAPI.Journal.Endpoints.Auth.Login;

public static class LoginEndpoint
{
    public static async Task<LoginResponse?> LoginAsync(this JournalApi journalApi, LoginRequest request)
    {
        return await Command.ExecuteAsync(() => journalApi.HttpService.PostAsync<LoginRequest, LoginResponse>(BaseEndpoints.LoginEndpoint, request), journalApi, isSkipCheckAccessToken: true);
    }
}