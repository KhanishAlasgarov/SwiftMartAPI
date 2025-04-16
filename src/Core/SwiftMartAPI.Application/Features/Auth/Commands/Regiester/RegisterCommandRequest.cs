using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace SwiftMartAPI.Application.Features.Auth.Commands.Regiester;

public class RegisterCommandRequest : IRequest
{
    public string Username { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}