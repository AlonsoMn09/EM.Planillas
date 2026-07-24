using EM.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Entities
{
    public class PayrollDetail : BaseEntity
    {
        public Guid PayrollId { get; private set; }
        public Payroll Payroll { get; private set; }
        public Guid EmployeeId { get; private set; }
        public string EmployeeFullName { get; private set; }
        public Employee Employee { get; private set; }
        public decimal AFP { get; private set; }
        public decimal TotalEarnings { get; private set; }
        public decimal TotalDeductions { get; private set; }
        public decimal NetPay { get; private set; } //=> TotalEarnings - TotalDeductions;
        public PayrollDetail()
        {
            
        }
        private PayrollDetail(Payroll payroll, Employee employee, decimal totalEarnings, decimal totalDeductions)
        {            
            PayrollId = payroll.Id;
            Payroll = payroll;
            Employee = employee;
            EmployeeId = employee.Id;
            EmployeeFullName = $"{employee.Name} {employee.LastName}";
            AFP = employee.BaseSalary.Amount * 0.10m;
            TotalEarnings = totalEarnings;
            TotalDeductions = totalDeductions;
            NetPay = TotalEarnings - TotalDeductions;
        }
        public static PayrollDetail Create(Payroll payroll, Employee employee, decimal totalEarnings, decimal totalDeductions)
        {
            return new PayrollDetail(payroll, employee, totalEarnings, totalDeductions);
        }
        public void CreatePaymentDetail(Payroll payroll, Guid id)
        {
            Id = id;
        }
    }
}
