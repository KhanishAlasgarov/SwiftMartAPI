using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IEnumerable<GetAllProductsQueryResponse>>
{
    public GetAllProductsQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public IUnitOfWork _uow { get; }
    public IMapper _mapper { get; }
    public async Task<IEnumerable<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await _uow.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(p => p.Brand!).Include(p => p.ProductCategories!).ThenInclude(x => x.Category!));

        return _mapper.Map<IEnumerable<GetAllProductsQueryResponse>>(products);

    }
}
