using AutoMapper;
using SwiftMartAPI.Application.DTOs;
using SwiftMartAPI.Application.Features.Products.Commands.CreateProduct;
using SwiftMartAPI.Application.Features.Products.Commands.UpdateProduct;
using SwiftMartAPI.Application.Features.Products.Queries.GetAllProducts;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, GetAllProductsQueryResponse>().ForMember(destinationMember: x => x.Price, memberOptions:
            opt => opt.MapFrom(x => x.Price - (x.Price * x.Discount / 100))).ForMember(destinationMember: x => x.Categories, memberOptions: opt => opt.MapFrom(x => x.ProductCategories.Select(x => new CategoryDto { Name = x.Category.Name })));



        CreateMap<CreateProductCommandRequest, Product>();

        CreateMap<UpdateProductCommandRequest, Product>();


    }
}
