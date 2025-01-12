using SwiftMartAPI.Application.DTOs;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryResponse
{
    public string Title { get; set; }
    public string Description { get; set; } 
    public decimal Price { get; set; }
    public BrandDto Brand { get; set; }
}
    