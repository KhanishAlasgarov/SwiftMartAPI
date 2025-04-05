using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SwiftMartAPI.Application.Interfaces.Tokens;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Infrastructure.Tokens;

public class TokenService : ITokenService
{
    private TokenSettings TokenSettings { get; }
    private UserManager<User> UserManager { get; }

    public TokenService(UserManager<User> userManager, IOptions<TokenSettings> options)
    {
        UserManager = userManager;
        TokenSettings = options.Value;
    }

    public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!)
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSettings.Secret));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: TokenSettings.Issuer,
            audience: TokenSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(TokenSettings.TokenValidityInMinutes),
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials
        );

        await UserManager.AddClaimsAsync(user, claims);
        return token;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        TokenValidationParameters tokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSettings.Secret)),
            ValidateLifetime = false
        };

        JwtSecurityTokenHandler tokenHandler = new();
        ;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters,
            out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Token not found'");

        return principal;
    }
}