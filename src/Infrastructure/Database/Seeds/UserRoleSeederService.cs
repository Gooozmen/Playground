using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Seeds;

public class UserRoleSeederService : ISeederService
{
    private readonly PlaygroundDbContext _context;

    public UserRoleSeederService(PlaygroundDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (!await _context.UserRoles.AnyAsync())
        {
            var roles = new List<UserRole>
            {
                new UserRole {Id = "A1", Description = "admin"},
                new UserRole {Id = "C1", Description = "customer"}
            };
            await _context.UserRoles.AddRangeAsync(roles);
        }
    }
}