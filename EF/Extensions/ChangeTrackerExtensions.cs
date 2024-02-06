using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EF.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static void ChangeForEntityStateAdded(this ChangeTracker changeTracker)
        {
            var entries = changeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is DataEntity);
            foreach (var entry in entries)
            {
                entry.Property(nameof(DataEntity.CreatedOn)).CurrentValue = DateTime.UtcNow;
                entry.Property(nameof(DataEntity.ModifiedOn)).CurrentValue = DateTime.UtcNow;
            }
        }

        public static void ChangeForEntityStateModified(this ChangeTracker changeTracker)
        {
            var entries = changeTracker.Entries().Where(e => e.State == EntityState.Modified && e.Entity is DataEntity);
            foreach (var entry in entries)
            {
                entry.Property(nameof(DataEntity.CreatedOn)).IsModified = false;
                entry.Property(nameof(DataEntity.ModifiedOn)).CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
