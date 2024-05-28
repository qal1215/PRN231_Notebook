namespace Lab3.API.Exceptions;

public class AuthenticationException : Exception
{
    public AuthenticationException(string message) : base(message)
    {
    }

    public AuthenticationException(string message, string details) : base(message)
    {
        Details = details;
    }

    public string? Details { get; }
}
