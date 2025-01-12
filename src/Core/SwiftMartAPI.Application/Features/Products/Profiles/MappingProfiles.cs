using AutoMapper;
using SwiftMartAPI.Application.DTOs;
using SwiftMartAPI.Application.Features.Products.Queries.GetAllProducts;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, GetAllProductsQueryResponse>().ForMember(destinationMember: x => x.Price, memberOptions:
            opt => opt.MapFrom(x => x.Price - (x.Price * x.Discount / 100)));

       
    }
}
