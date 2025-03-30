using AutoMapper;
using MediatR;
using SwiftMartAPI.Application.Features.Products.Rules;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
{
    public CreateProductCommandHandler(IUnitOfWork uow, IMapper mapper, ProductRules productRules)
    {
        _uow = uow;
        _mapper = mapper;
        _productRules = productRules;
    }

    private IUnitOfWork _uow { get; }
    private IMapper _mapper { get; }
    private ProductRules _productRules { get; }

    public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _productRules.ProductTitleShouldNotBeRepeated(request.Title);
        var product = _mapper.Map<Product>(request);

        await _uow.GetWriteRepository<Product>().AddAsync(product);

        var existingCategories = await _uow.GetReadRepository<Category>()
            .GetAllAsync(predicate: x => request.CategoryIds.Contains(x.Id));

        if (existingCategories.Count() != request.CategoryIds.Count())
            throw new Exception("Some category IDs are invalid.");

        var productCategories =
            request.CategoryIds.Select(x => new ProductCategory { CategoryId = x, Product = product });


        await _uow.GetWriteRepository<ProductCategory>().AddRangeAsync(productCategories);

        await _uow.SaveAsync();
    }
}