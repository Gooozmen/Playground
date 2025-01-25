using AutoMapper;
using Domain.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shared.DTOs.ApplicationUser;

namespace Infrastructure.Managers;

public class ApplicationUserManager : IApplicationUserManager
{
    private readonly IServiceProvider _serviceProvider;

    public ApplicationUserManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<IdentityResult> CreateApplicationUserAsync(ApplicationUserCommand command)
    {
        var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var mapper = _serviceProvider.GetRequiredService<IMapper>();
        var user = mapper.Map<ApplicationUser>(command);
        user.UserName = command.Email;
        return await userManager.CreateAsync(user);
    }
    
}

public interface IApplicationUserManager
{
    Task<IdentityResult> CreateApplicationUserAsync(ApplicationUserCommand command);
}
