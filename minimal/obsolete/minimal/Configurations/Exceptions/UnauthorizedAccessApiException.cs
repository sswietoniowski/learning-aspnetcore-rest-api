namespace minimal.Configurations.Exceptions;

public class UnauthorizedAccessApiException : ApiException
{
    public UnauthorizedAccessApiException() : base() { }

    public UnauthorizedAccessApiException(string message) : base(message)
    {
    }
}