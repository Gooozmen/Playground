using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Shared.Helpers;
using Domain.Entities;
using Infrastructure.Extensions;

namespace Infrastructure.Interceptors;

public class DatabaseChangesInterceptor : SaveChangesInterceptor
{
    private readonly IDateTimeHelper _dateTimeHelper;
    public DatabaseChangesInterceptor(IDateTimeHelper dateTimeHelper)
    {
        _dateTimeHelper = dateTimeHelper;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData,result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<Auditable>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = _dateTimeHelper.Now;
                entry.Entity.CreatedBy = "c1e96611-a4b5-425e-84b5-4048d68321e6"
            }

            //if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
            //{
            //    entry.Entity.UpdatedAt = _dateTimeHelper.Now;
            //}
        }
    }
}
