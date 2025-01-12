using MediatR;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IEnumerable<GetAllProductsQueryResponse>>
{
    public GetAllProductsQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public IUnitOfWork _uow { get; }
    public async Task<IEnumerable<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await _uow.GetReadRepository<Product>().GetAllAsync();

        return products.Select(x => new GetAllProductsQueryResponse
        {
            Description = x.Description,
            Price = x.Price - (x.Price * x.Discount / 100),
            Title = x.Title
        }).ToList();

    }
}
