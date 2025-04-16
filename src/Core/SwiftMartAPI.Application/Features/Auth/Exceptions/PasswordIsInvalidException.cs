using SwiftMartAPI.Application.Features.Products.Exceptions;

namespace SwiftMartAPI.Application.Features.Auth.Exceptions;

public class PasswordIsInvalidException : BaseExceptions
{
    public PasswordIsInvalidException() : base("Password is Invalid!")
    {
        
    }
}