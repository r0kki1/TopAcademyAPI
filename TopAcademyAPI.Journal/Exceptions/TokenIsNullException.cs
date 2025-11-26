namespace TopAcademyAPI.Journal.Exceptions;

public class TokenIsNullException(
    string message = "Токен не указан.")
    : Exception(message);
    
    