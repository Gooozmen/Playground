using Infrastructure.Extensions;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;
public class CommandRepository<T> : ICommandRepository<T> where T : class
{
    private readonly DbContext _context;

    public CommandRepository(DbContext context) => _context = context;

    private DbSet<T> Set => _context.CommandSet<T>();

    public void Add(T item) => Set.Add(item);

    public async Task AddAsync(T item) => await Set.AddAsync(item).AsTask();

    public void AddRange(IEnumerable<T> items) => Set.AddRange(items);

    public async Task AddRangeAsync(IEnumerable<T> items) => await Set.AddRangeAsync(items);

    public void Delete(object key)
    {
        var item = Set.Find(key);

        if (item is null) return;

        Set.Remove(item);
    }

    public void Delete(Expression<Func<T, bool>> where)
    {
        var items = Set.Where(where);

        if (!items.Any()) return;

        Set.RemoveRange(items);
    }

    public async Task DeleteAsync(object key) => await Task.Run(() => Delete(key));

    public async Task DeleteAsync(Expression<Func<T, bool>> where) => await Task.Run(() => Delete(where));

    public void Update(T item)
    {
        var primaryKeyValues = _context.PrimaryKeyValues<T>(item);

        var entity = Set.Find(primaryKeyValues);

        if (entity is null) return;

        _context.Entry(entity).State = EntityState.Detached;

        _context.Update(item);
    }

    public async Task UpdateAsync(T item) => await Task.Run(() => Update(item));

    public void UpdatePartial(object item)
    {
        var primaryKeyValues = _context.PrimaryKeyValues<T>(item);

        var entity = Set.Find(primaryKeyValues);

        if (entity is null) return;

        var entry = _context.Entry(entity);
        var itemProperties = item.GetType().GetProperties();

        foreach (var property in itemProperties)
        {
            var itemValue = property.GetValue(item);

            var entityProperty = entry.CurrentValues.Properties.FirstOrDefault(p => p.Name == property.Name);

            if (itemValue != null && !itemValue.Equals(0) && !itemValue.Equals(string.Empty))
                entry.CurrentValues[entityProperty.Name] = itemValue;
        }
    }

    public async Task UpdatePartialAsync(object item) => await Task.Run(() => UpdatePartial(item));

    public void UpdateRange(IEnumerable<T> items) => Set.UpdateRange(items);

    public async Task UpdateRangeAsync(IEnumerable<T> items) => await Task.Run(() => UpdateRange(items));

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}

