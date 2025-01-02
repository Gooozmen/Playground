
using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(PlaygroundDbContext context) : base(context)
    {}
}

public interface IUserRepository : IBaseRepository<User>
{}