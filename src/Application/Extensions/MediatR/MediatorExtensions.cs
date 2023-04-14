using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class MediatorExtensions
{
    public static async Task DispatchDomainEvents(this IPublisher publisher, IEnumerable<BaseEntity> entities)
    {

        //var entities = context.ChangeTracker
        //    .Entries<BaseEntity>()
        //    .Where(e => e.Entity.DomainEvents.Any())
        //    .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents) {
            await publisher.Publish(domainEvent);
        }
    }

    public static async Task DispatchDomainEvents(this IPublisher publisher, DbContext context)
    {

        var entities = context.ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);
        await DispatchDomainEvents(publisher, entities);
    }
}
