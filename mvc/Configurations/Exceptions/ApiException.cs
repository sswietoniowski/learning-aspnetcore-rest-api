namespace mvc.Configurations.Exceptions;

public class ApiException : Exception
{
    public ApiException() : base() { }

    public ApiException(string message) : base(message)
    {
    }
}