using EM.Planilla.Domain.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Events.Domains
{
    public class PayrollCreateDomainEvent : IDomainEvent
    {
        public Guid PayrollId { get; }
        public Guid Id => Guid.NewGuid();
        public DateTime OcurredOn => DateTime.UtcNow;
        public PayrollCreateDomainEvent(Guid payrollId)
        {
            PayrollId = payrollId;
        }
    }
}
