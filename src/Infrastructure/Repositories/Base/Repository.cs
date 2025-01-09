using Infrastructure.Database;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class Repository<T> : BaseRepository<T> where T : class
{
    public Repository(ApplicationDbContext context) 
        : base
        (
            new CommandRepository<T>(context), 
            new QueryRepository<T>(context)
        ) 
    { }
}

