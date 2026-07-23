using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Entities
{
    public class PayrollDetail : BaseEntity
    {
        public Guid PayrollId { get; set; }
        public Payroll Payroll { get; set; }
        public PayrollDetail()
        {
            
        }
        private PayrollDetail(Payroll payroll)
        {
            PayrollId = payroll.Id;
            Payroll = payroll;

            AddDomainEvent(
                new Events.Domains.PayrollCreateDomainEvent
                (
                    payroll.Id
                )
            );
        }
        public static PayrollDetail Create(Payroll payroll)
        {
            return new PayrollDetail(payroll);
        }
        public void CreatePaymentDetail(Payroll payroll, Guid id)
        {
            Id = id;
        }
    }
}
