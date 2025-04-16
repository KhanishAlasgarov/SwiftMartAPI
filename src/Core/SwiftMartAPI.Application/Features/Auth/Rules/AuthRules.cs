using Microsoft.AspNetCore.Identity;
using SwiftMartAPI.Application.Bases;
using SwiftMartAPI.Application.Features.Auth.Exceptions;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Auth.Rules;

public class AuthRules : BaseRules
{
    public AuthRules(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public UserManager<User> _userManager { get; set; }

    internal async Task<User> EmailIsExist(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            throw new EmailIsNotExistException();

        return user;
    }

    internal async Task CheckPassword(User user, string password)
    {
        bool checkPassword = await _userManager.CheckPasswordAsync(user, password);

        if (!checkPassword)
            throw new PasswordIsInvalidException();

    }
    internal void UserShouldNotBeExisted(User? user)
    {
        if (user is not null)
            throw new UserAlreadyExistException();
    }
}