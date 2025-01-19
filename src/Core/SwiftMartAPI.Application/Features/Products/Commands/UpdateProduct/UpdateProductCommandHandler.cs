using AutoMapper;
using MediatR;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
{
    public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork uow)
    {
        _mapper = mapper;
        _uow = uow;
    }

    private IMapper _mapper { get; set; }
    private IUnitOfWork _uow { get; set; }
    public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {

        var existProduct = await _uow.GetReadRepository<Product>()
            .GetAsync(x => x.Id == request.Id && !x.IsDeleted);

        if (existProduct == null)
            throw new Exception("Product not found.");

        var newProduct = _mapper.Map<Product>(request);

        var categoriesToRemove = await _uow.GetReadRepository<ProductCategory>()
            .GetAllAsync(x => x.ProductId == request.Id && !request.Categories.Contains(x.CategoryId));

        if (categoriesToRemove.Any())
            _uow.GetWriteRepository<ProductCategory>().HardRangeDelete(categoriesToRemove);

        var existingCategories = await _uow.GetReadRepository<ProductCategory>()
            .GetAllAsync(pc => request.Categories.Contains(pc.CategoryId));

        var existingCategoryIds = existingCategories.Select(x => x.CategoryId).ToHashSet();

        var newCategoryIds = request.Categories.Where(categoryId => !existingCategoryIds.Contains(categoryId)).ToList();

        if (newCategoryIds.Any())
        {
            var newProductCategories = newCategoryIds.Select(categoryId => new ProductCategory
            {
                ProductId = request.Id,
                CategoryId = categoryId
            }).ToList();

            await _uow.GetWriteRepository<ProductCategory>().AddRangeAsync(newProductCategories);
        }

        _uow.GetWriteRepository<Product>().Update(newProduct);

        await _uow.SaveAsync();
    }
}
