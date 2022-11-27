namespace minimal.Configurations.Exceptions;

public class BadRequestApiException : ApiException
{
    public BadRequestApiException() : base() { }

    public BadRequestApiException(string message) : base(message)
    {
    }
}
