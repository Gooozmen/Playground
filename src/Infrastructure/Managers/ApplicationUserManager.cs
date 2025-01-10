using Domain.Identities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Managers;

public class ApplicationUserManager : IApplicationUserManager
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserManager(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUserAsync(string email, string password)
    {
        var user = new ApplicationUser { UserName = email, Email = email };
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<bool> AuthenticateUserAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return false;
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) throw new Exception("User not found.");
        return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    }
}

public interface IApplicationUserManager
{
    Task<bool> AuthenticateUserAsync(string email, string password);
    Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
    Task<IdentityResult> RegisterUserAsync(string email, string password);
}
