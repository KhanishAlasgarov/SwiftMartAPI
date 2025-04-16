using FluentValidation;

namespace SwiftMartAPI.Application.Features.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommandRequest>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MinimumLength(8).MaximumLength(60);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }
}


