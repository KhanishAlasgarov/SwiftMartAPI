using MediatR;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandRequest : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int BrandId { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public IEnumerable<int> CategoryIds { get; set; }
}

 