namespace TopAcademyAPI.Journal.Endpoints;

public static class BaseEndpoints
{
    public const string ReferrerEndpoint = "https://journal.top-academy.ru/";
    public const string LoginEndpoint  = BaseEndpoint + "auth/login";
    public const string UserInfoEndpoint  = BaseEndpoint + "settings/user-info";
    public const string HomeworkEndpoint  = BaseEndpoint + "count/homework";
    public const string ListHomeworkEndpoint  = BaseEndpoint + "homework/operations/list";
    
    private const string BaseEndpoint = "https://msapi.top-academy.ru/api/v2/";
}