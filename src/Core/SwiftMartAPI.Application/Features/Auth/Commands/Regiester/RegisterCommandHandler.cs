using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SwiftMartAPI.Application.Features.Auth.Rules;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Auth.Commands.Regiester;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest>
{
    /*IHttpContextAccessor httpContextAccessor */
    public RegisterCommandHandler(IMapper mapper, IUnitOfWork uow, 
        AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _mapper = mapper;
        _uow = uow;
        // _HttpContextAccessor = httpContextAccessor;
        _authRules = authRules;
        _UserManager = userManager;
        _RoleManager = roleManager;
        // UserId = Guid.Parse(httpContextAccessor.HttpContext?.User?
        //     .FindFirstValue(ClaimTypes.NameIdentifier)!);
    }

    private IMapper _mapper { get; }
    private IUnitOfWork _uow { get; }
    // private IHttpContextAccessor _HttpContextAccessor { get; }

    private AuthRules _authRules { get; }
    // private Guid UserId { get; }
    private UserManager<User> _UserManager { get; }
    private RoleManager<Role> _RoleManager { get; }

    public async Task Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        _authRules.UserShouldNotBeExisted(await _UserManager.FindByEmailAsync(request.Email));
        User user = _mapper.Map<User>(request);
        user.SecurityStamp = Guid.NewGuid().ToString();

        IdentityResult result = await _UserManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            if (!await _RoleManager.RoleExistsAsync("user"))
                await _RoleManager.CreateAsync(new Role()
                {
                    Name = "user",
                    Id = Guid.NewGuid(),
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            
            await _UserManager.AddToRoleAsync(user, "user");

        }
    }
}