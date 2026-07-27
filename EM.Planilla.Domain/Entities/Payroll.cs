using EM.Planilla.Domain.Enums;
using EM.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Entities
{
    public class Payroll : BaseEntity
    {
        public Period Period { get; private set; }
        public PayrollStatus Status { get; private set; }
        public DateTime ProcessingDate { get; private set; }      
        public Money TotalAmount { get; private set; }
        public readonly List<PayrollDetail> _payments = new();
        public IReadOnlyCollection<PayrollDetail> Payments => _payments.AsReadOnly();
        public Payroll()
        {
            
        }
        private Payroll(Period period)
        {
            Period = period;
            Status = PayrollStatus.Pending;
            ProcessingDate = DateTime.UtcNow;
            TotalAmount = Money.Create("PEN", 0);
            AddDomainEvent(
               new Events.Domains.PayrollCreateDomainEvent
               (
                   Id
               )
           );
        }
        public static Payroll Create(Period period) 
        {
            return new Payroll(period);
        }
        public void Processing()
        {
            if (Status != PayrollStatus.Pending)
                throw new InvalidOperationException("Only pending payrolls can be processing.");

            Status = PayrollStatus.Processing;
        }
        public void Completed()
        {
            if (Status != PayrollStatus.Pending)//Processing
                throw new InvalidOperationException("Only procesing payrolls can be completed.");

            Status = PayrollStatus.Completed;
            UpdatedAt = DateTime.UtcNow;            
        }
    }
}
