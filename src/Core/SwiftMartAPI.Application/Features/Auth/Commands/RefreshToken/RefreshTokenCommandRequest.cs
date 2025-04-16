using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SwiftMartAPI.Application.Features.Auth.Exceptions;
using SwiftMartAPI.Application.Features.Auth.Rules;
using SwiftMartAPI.Application.Interfaces.Tokens;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SwiftMartAPI.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{

    public RefreshTokenCommandHandler(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, AuthRules authRules, RoleManager<Role> roleManager, ITokenService tokenService, IConfiguration configuration)
    {
        _httpContextAccessor = httpContextAccessor;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
        _authRules = authRules;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _configuration = configuration;
    }

    private IConfiguration _configuration { get; set; }
    private IHttpContextAccessor _httpContextAccessor { get; }
    private IUnitOfWork _unitOfWork { get; }
    private IMapper _mapper { get; }
    private UserManager<User> _userManager { get; }
    private RoleManager<Role> _roleManager { get; }
    private AuthRules _authRules { get; }
    private ITokenService _tokenService { get; }
    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        string email = principal.FindFirstValue(ClaimTypes.Email);

        var user = await _userManager.FindByEmailAsync(email);

         
        var roles = await _userManager.GetRolesAsync(user);

        if (user.RefreshTokenExpriryTime <= DateTime.UtcNow)
            throw new RefreshTokenExpiredException();

        var token = await _tokenService.CreateToken(user, roles);

        string newRefreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await _userManager.UpdateAsync(user);

        return new RefreshTokenCommandResponse
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
            RefreshToken = newRefreshToken,
        };
    }
}
