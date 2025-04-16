using AutoMapper;
using SwiftMartAPI.Application.Features.Auth.Commands.Regiester;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Auth.Profiles;

public class AuthProfile:Profile
{
    public AuthProfile()
    {
        CreateMap<RegisterCommandRequest, User>().ReverseMap();
    }
}