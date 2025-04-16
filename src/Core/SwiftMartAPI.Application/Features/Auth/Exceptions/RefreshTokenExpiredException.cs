using SwiftMartAPI.Application.Features.Products.Exceptions;

namespace SwiftMartAPI.Application.Features.Auth.Exceptions;

public class RefreshTokenExpiredException : BaseExceptions
{
    public RefreshTokenExpiredException() : base("Your session has expired. Please log in again.")
    {

    }
}