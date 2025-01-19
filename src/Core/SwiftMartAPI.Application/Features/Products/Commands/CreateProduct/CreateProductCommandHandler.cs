using AutoMapper;
using MediatR;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
{
    public CreateProductCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    private IUnitOfWork _uow { get; }
    private IMapper _mapper { get; }
    public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        await _uow.GetWriteRepository<Product>().AddAsync(product);

        var existingCategories = await _uow.GetReadRepository<Category>().GetAllAsync(predicate: x => request.CategoryIds.Contains(x.Id));

        if (existingCategories.Count() != request.CategoryIds.Count())
            throw new Exception("Some category IDs are invalid.");

        var productCategories = request.CategoryIds.Select(x => new ProductCategory { CategoryId = x, Product = product });


        await _uow.GetWriteRepository<ProductCategory>().AddRangeAsync(productCategories);

        await _uow.SaveAsync();
    }
}
