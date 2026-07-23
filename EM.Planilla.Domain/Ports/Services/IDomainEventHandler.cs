using EM.Planilla.Domain.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Ports.Services
{
    public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
    {
        Task HandlerAsync(TEvent domainEvent);
    }
}
