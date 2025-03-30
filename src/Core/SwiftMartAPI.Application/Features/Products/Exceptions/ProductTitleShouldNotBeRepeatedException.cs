namespace SwiftMartAPI.Application.Features.Products.Exceptions;

public class ProductTitleShouldNotBeRepeatedException : BaseExceptions
{
    public ProductTitleShouldNotBeRepeatedException() : base("Product title already exists!")
    {
    }
}