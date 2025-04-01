using Microsoft.AspNetCore.Identity;

namespace SwiftMartAPI.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string FullName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpriryTime { get; set; }
}