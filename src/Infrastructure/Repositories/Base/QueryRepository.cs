using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Base;

public class QueryRepository<T> : IQueryRepository<T> where T : class
{
    private readonly DbContext _context;

    public QueryRepository(DbContext context) => _context = context;

    public IQueryable<T> Queryable => _context.QuerySet<T>();

    public bool Any() => Queryable.Any();

    public bool Any(Expression<Func<T, bool>> where) => Queryable.Any(where);

    public async Task<bool> AnyAsync() => await Queryable.AnyAsync();

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> where) => await Queryable.AnyAsync(where);

    public long Count() => Queryable.LongCount();

    public long Count(Expression<Func<T, bool>> where) => Queryable.LongCount(where);

    public async Task<long> CountAsync() => await Queryable.LongCountAsync();

    public async Task<long> CountAsync(Expression<Func<T, bool>> where) => await Queryable.LongCountAsync(where);

    public T Get(object key) => _context.DetectChangesLazyLoading(false).Set<T>().Find(key);

    public async Task<T> GetAsync(object key) => await _context.DetectChangesLazyLoading(false).Set<T>().FindAsync(key).AsTask();

    public IEnumerable<T> List() => Queryable.ToList();

    public async Task<IEnumerable<T>> ListAsync() => await Queryable.ToListAsync().ConfigureAwait(false);
}