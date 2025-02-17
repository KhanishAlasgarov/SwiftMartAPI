using FluentValidation;

namespace SwiftMartAPI.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithName("Başlıq");

        RuleFor(x => x.Description).NotEmpty();

        RuleFor(x => x.BrandId).GreaterThan(0);

        RuleFor(x => x.Price).GreaterThan(0);

        RuleFor(x => x.Discount).GreaterThanOrEqualTo(0);

        RuleFor(x => x.CategoryIds).Must(c => c.Any());
    }
}
