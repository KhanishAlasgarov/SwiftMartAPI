using FluentValidation;

namespace SwiftMartAPI.Application.Features.Auth.Commands.Regiester;

public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(3);

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(60)
            .EmailAddress()
            .MinimumLength(8);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithName("Parol Parol");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .MinimumLength(6)
            .Equal(x => x.Password);
    }
}