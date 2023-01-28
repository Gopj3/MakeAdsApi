using System;
using System.Linq;
using MakeAdsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MakeAdsApi.Infrastructure.Extensions;

public static class ChangeTrackerExtension
{
    public static void TimeStampsAndSoftDeletion(this ChangeTracker changeTracker)
    {
        var entries = changeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity)
            .Where(e =>
                e.State == EntityState.Added
                || e.State == EntityState.Modified
                || e.State == EntityState.Deleted
            );

        foreach (var entityEntry in entries)
        {
            var entity = entityEntry.Entity as BaseEntity;
            if (entity == null) continue;

            entity.UpdatedAt = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Deleted)
            {
                entityEntry.State = EntityState.Modified;
                entity.DeletedAt = DateTime.UtcNow;
            }
        }
    }
}