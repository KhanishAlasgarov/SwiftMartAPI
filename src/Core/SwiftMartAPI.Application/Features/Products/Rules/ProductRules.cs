using SwiftMartAPI.Application.Bases;
using SwiftMartAPI.Application.Features.Products.Exceptions;
using SwiftMartAPI.Application.Interfaces.Repositories;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Rules;

public class ProductRules : BaseRules
{
    public ProductRules(IReadRepository<Product> readRepository)
    {
        _readRepository = readRepository;
    }

    private IReadRepository<Product> _readRepository { get; }

    internal async Task ProductTitleShouldNotBeRepeated(string title)
    {
        var product = await _readRepository.GetAsync(product => product.Title == title);
        if (product is not null) throw new ProductTitleShouldNotBeRepeatedException();
    }
}