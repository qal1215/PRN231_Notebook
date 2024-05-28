namespace Lab3.API.Exceptions.Handler;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(string message, string details) : base(message)
    {
        Details = details;
    }

    public string? Details { get; }
}

