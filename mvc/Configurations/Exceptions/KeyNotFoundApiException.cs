namespace mvc.Configurations.Exceptions;

public class KeyNotFoundApiException : ApiException
{
    public KeyNotFoundApiException() : base() { }

    public KeyNotFoundApiException(string message) : base(message)
    {
    }
}