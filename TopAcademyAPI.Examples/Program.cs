using TopAcademyAPI.Journal;
using TopAcademyAPI.Journal.Endpoints.Auth.Login;
using TopAcademyAPI.Journal.Endpoints.Count.Homework;
using TopAcademyAPI.Journal.Endpoints.Homework.Operations.List;
using TopAcademyAPI.Journal.Endpoints.Settings.UserInfo;

var journalApi = new JournalApi();

var loginRequest = new LoginRequest("gariz_oe01", "AcTop2809");

var loginResponse = await journalApi.LoginAsync(loginRequest);

Console.WriteLine(loginResponse);

var homeworkResponse = await journalApi.HomeworkAsync();

if (homeworkResponse != null)
{
    foreach (var homework  in homeworkResponse)
    {
        Console.WriteLine($"Тип домашнего задания {homework.CounterType} - {homework.Counter} штук ");
    }
}


// Type - хз, что это
// Group id = id группы, но можно оставлять Null, так как само поймет
// Status - это статус домашки, типо просрочено, задано и т д 
// Page - это страница, выдает по 6 домашек, поэтому надо сначала получить список, где указан тип домашнего задания с его количеством, потом поделить и потом циклом пройтись

var listHomeworkResponse = await journalApi.ListHomeworkAsync(1, 0, 3);

if (listHomeworkResponse != null)
{
    Console.WriteLine(listHomeworkResponse.Count);
    foreach (var homework  in listHomeworkResponse)
    {
       
        Console.WriteLine(homework);
    }
}

var userInfoResponse = await journalApi.UserInfoAsync();

Console.WriteLine(userInfoResponse?.FullName);