using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SwiftMartAPI.Application.Features.Auth.Rules;
using SwiftMartAPI.Application.Interfaces.Tokens;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace SwiftMartAPI.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    public LoginCommandHandler(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, AuthRules authRules, RoleManager<Role> roleManager, ITokenService tokenService, IConfiguration configuration)
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
    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _authRules.EmailIsExist(request.Email);

        await _authRules.CheckPassword(user, request.Password);

        var roles = await _userManager.GetRolesAsync(user);

        JwtSecurityToken token = await _tokenService.CreateToken(user, roles);
        string refreshToken = _tokenService.GenerateRefreshToken();

        int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpriryTime = DateTime.UtcNow.AddDays(refreshTokenValidityInDays);

        await _userManager.UpdateAsync(user);
        await _userManager.UpdateSecurityStampAsync(user);


        var _token = new JwtSecurityTokenHandler().WriteToken(token);

        await _userManager.SetAuthenticationTokenAsync(user, "default", "AccessToken",_token);

        return new()
        {
            Token=_token,
            RefreshToken = refreshToken,
            Expiration = token.ValidTo,
        };
    }
}


