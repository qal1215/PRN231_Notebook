namespace Lab3.API.Exceptions.Handler;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string name, object key) : base($"Entity {name} ({key}) was not found")
    {
    }
}

