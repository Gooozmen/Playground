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

    public async Task<IdentityResult> RegisterUserAsync(CreateApplicationUserCommand command)
    {
        var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var mapper = _serviceProvider.GetRequiredService<IMapper>();
        var user = mapper.Map<ApplicationUser>(command);
        return await userManager.CreateAsync(user);
    }

    public async Task<bool> AuthenticateUserAsync(string email, string password)
    {
        var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var user = await userManager.FindByEmailAsync(email);
        if (user == null) return false;
        return await userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
    {
        var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var user = await userManager.FindByIdAsync(userId);
        if (user == null) throw new Exception("User not found.");
        return await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    }
}

public interface IApplicationUserManager
{
    Task<bool> AuthenticateUserAsync(AuthenticateApplicationUserCommand command);
    Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
    Task<IdentityResult> RegisterUserAsync(CreateApplicationUserCommand command);
}
