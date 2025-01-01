using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly PlaygroundDbContext _context;

    public UserService(PlaygroundDbContext context)
    {
        _context = context;
    }

    public async Task<User> ExecuteGetAsync()
    {
        var result = await _context.Users
            .Include(r => r.Role)
            .FirstOrDefaultAsync(x => x.FirstName.Equals("Admin"));

        return result;
    }
}

public interface IUserService
{
    Task<User> ExecuteGetAsync();
}