
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Seeds;

public class UserSeederService : ISeederService
{
    private readonly ApplicationDbContext _context;

    public UserSeederService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (!await _context.UserRoles.AnyAsync())
        {
            var users = new List<User>
            {
                new User
                {
                    RoleId = "A1",
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@example.com",
                    Password = "Admin123!"
                },
                new User
                {
                    RoleId = "C1",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Password = "John123!" // Ideally, hash this password
                }
            };
            await _context.Users.AddRangeAsync(users);
        }
    }
}