using EM.Planilla.Domain.Ports.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Infraestructure.Adapters.Services
{
    public class DomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task DispatchEventAsync(DbContext context)
        {
            var entities = context.ChangeTracker
                .Entries<Domain.Entities.BaseEntity>()
                .Where(e => e.Entity.DomainEvents.Any())
                .ToList();

            var events = entities
                .SelectMany(e => e.Entity.DomainEvents)
                .ToList();

            entities.ForEach(e => e.Entity.RemoveDomainEvent());

            foreach (var domainEvent in events)
            {
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
                var handlers = _serviceProvider.GetServices(handlerType);

                foreach (var handler in handlers)
                {
                    var method = handlerType.GetMethod("HandlerAsync");
                    await (Task)method!.Invoke(handler, new object[] { domainEvent })!;
                }

            }
        }
    }
}
