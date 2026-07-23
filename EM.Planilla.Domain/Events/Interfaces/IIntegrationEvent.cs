using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Events.Interfaces
{
    public interface IIntegrationEvent
    {
        Guid Id { get; }
        DateTime OcurredOn { get; } 
    }
}
