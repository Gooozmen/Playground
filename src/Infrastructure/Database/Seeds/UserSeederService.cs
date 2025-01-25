
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
                    FirstName = "Admin",
                    LastName = "User"
                },
                new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                }
            };
            await _context.Users.AddRangeAsync(users);
        }
    }
}