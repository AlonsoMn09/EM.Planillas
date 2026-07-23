using EM.Planilla.Domain.Enums;
using EM.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Entities
{
    public class Payroll : BaseEntity
    {
        public Period Period { get; set; }
        public PayrollStatus Status { get; set; }
        public readonly List<PayrollDetail> _payments = new();
        public IReadOnlyCollection<PayrollDetail> Payments => _payments.AsReadOnly();
        public Payroll()
        {
            
        }
        public Payroll(Period period)
        {
            if (period == null) throw new ArgumentNullException(nameof(period), "Period cannot be null");
            Period = period;
            Status = PayrollStatus.Pending;
        }
        public static Payroll Create(Period period) 
        {
            return new Payroll(period);
        }
    }
}
