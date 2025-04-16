using Microsoft.AspNetCore.Mvc;
using SwiftMartAPI.Application.Features.Auth.Commands.Login;
using SwiftMartAPI.Application.Features.Auth.Commands.RefreshToken;
using SwiftMartAPI.Application.Features.Auth.Commands.Regiester;

namespace SwiftMartAPI.API.Controllers;

public class AuthController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Register( RegisterCommandRequest request)
    {
        await Mediator.Send(request);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommandRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}