using SwiftMartAPI.Application.Features.Products.Exceptions;

namespace SwiftMartAPI.Application.Features.Auth.Exceptions;

public class UserAlreadyExistException : BaseExceptions
{
    public UserAlreadyExistException() : base("User already exists!")
    {
    }
}
