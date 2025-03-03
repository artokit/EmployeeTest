namespace Application.Exceptions.Abstractions;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string? message) : base(message) { }
}