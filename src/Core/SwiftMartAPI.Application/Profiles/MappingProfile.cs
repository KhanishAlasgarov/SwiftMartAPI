using AutoMapper;
using SwiftMartAPI.Application.DTOs;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Profiles;

internal class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Brand, BrandDto>().ReverseMap();
    }
}
