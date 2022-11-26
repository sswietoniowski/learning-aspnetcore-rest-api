namespace minimal.Configurations.Exceptions;

public class UnauthorizedAccessException : Exception
{
    public UnauthorizedAccessException(string message) : base(message)
    {
    }
}