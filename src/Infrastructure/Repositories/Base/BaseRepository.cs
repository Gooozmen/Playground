using Infrastructure.Repositories.Base;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ICommandRepository<T> _commandRepository;
    private readonly IQueryRepository<T> _queryRepository;

    protected BaseRepository
    (
        ICommandRepository<T> commandRepository,
        IQueryRepository<T> queryRepository
    )
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
    }

    public IQueryable<T> Queryable => _queryRepository.Queryable;

    public void Add(T item) => _commandRepository.Add(item);

    public async Task AddAsync(T item) => await _commandRepository.AddAsync(item);

    public void AddRange(IEnumerable<T> items) => _commandRepository.AddRange(items);

    public async Task AddRangeAsync(IEnumerable<T> items) => await  _commandRepository.AddRangeAsync(items);

    public bool Any() => _queryRepository.Any();

    public bool Any(Expression<Func<T, bool>> where) => _queryRepository.Any(where);

    public async Task<bool> AnyAsync() => await _queryRepository.AnyAsync();

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> where) => await _queryRepository.AnyAsync(where);

    public long Count() => _queryRepository.Count();

    public long Count(Expression<Func<T, bool>> where) => _queryRepository.Count(where);

    public async Task<long> CountAsync() => await _queryRepository.CountAsync();

    public async Task<long> CountAsync(Expression<Func<T, bool>> where) => await _queryRepository.CountAsync(where);

    public void Delete(object key) => _commandRepository.Delete(key);

    public void Delete(Expression<Func<T, bool>> where) => _commandRepository.Delete(where);

    public async Task DeleteAsync(object key) => await _commandRepository.DeleteAsync(key);

    public async Task DeleteAsync(Expression<Func<T, bool>> where) => await _commandRepository.DeleteAsync(where);

    public T Get(object key) => _queryRepository.Get(key);

    public async Task<T> GetAsync(object key) => await _queryRepository.GetAsync(key);

    public IEnumerable<T> List() => _queryRepository.List();

    public async Task<IEnumerable<T>> ListAsync() => await _queryRepository.ListAsync();

    public async Task SaveChangesAsync() => await _commandRepository.SaveChangesAsync();

    public void Update(T item) => _commandRepository.Update(item);

    public async Task UpdateAsync(T item) => await _commandRepository.UpdateAsync(item);

    public void UpdatePartial(object item) => _commandRepository.UpdatePartial(item);

    public async Task UpdatePartialAsync(object item) => await  _commandRepository.UpdatePartialAsync(item);

    public void UpdateRange(IEnumerable<T> items) => _commandRepository.UpdateRange(items);

    public async Task UpdateRangeAsync(IEnumerable<T> items) => await _commandRepository.UpdateRangeAsync(items);
}
