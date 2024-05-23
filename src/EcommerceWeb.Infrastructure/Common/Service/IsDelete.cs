using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceWeb.Application.Common.Services;

namespace EcommerceWeb.Infrastructure.Common.Service
{
    public class IsDelete : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {

            if (eventData.Context is null)
            {
                return base.SavingChangesAsync(
                    eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<IIsDelete>> entries =
                eventData
                    .Context
                    .ChangeTracker
                    .Entries<IIsDelete>()
                    .Where(e => e.State == EntityState.Deleted);

            foreach (EntityEntry<IIsDelete> softDeletable in entries)
            {
                softDeletable.State = EntityState.Modified;
                softDeletable.Entity.IsDeleted = true;
                softDeletable.Entity.DeletedOnUtc = DateTime.UtcNow;
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
