using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Events.Integration
{
    public class PayrollCreatedIntegrationEvent
    {
        public Guid Id => Guid.NewGuid();
        public Guid PayrollId { get; }
        public DateTime OcurredOn => DateTime.UtcNow;
        public PayrollCreatedIntegrationEvent(Guid payrollId)
        {
            PayrollId = payrollId;
        }
    }
}
