using MediatR;

namespace SwiftMartAPI.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryRequest:IRequest<IEnumerable<GetAllProductsQueryResponse>>
{

}
