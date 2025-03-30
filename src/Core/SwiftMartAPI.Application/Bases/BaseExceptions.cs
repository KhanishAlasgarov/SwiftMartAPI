namespace SwiftMartAPI.Application.Features.Products.Exceptions;

public class BaseExceptions : ApplicationException
{
    public BaseExceptions()
    {
    }

    public BaseExceptions(string message) : base(message)
    {
    }
}