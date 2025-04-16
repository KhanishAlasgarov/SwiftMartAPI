using SwiftMartAPI.Application.Features.Products.Exceptions;

namespace SwiftMartAPI.Application.Features.Auth.Exceptions;

public class EmailIsNotExistException : BaseExceptions
{
    public EmailIsNotExistException() : base("Email is not exist")
    {
        
    }
}
