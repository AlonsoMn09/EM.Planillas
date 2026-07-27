using EM.Planilla.Domain.Entities;
using EM.Planilla.Domain.ValueObjects;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace EM.Planilla.Domain.Services
{
    public class PayrollDetailService : IPayrollDetailService
    {
        public IEnumerable<PayrollDetail> GeneratePayrollDetail(Payroll payroll, ICollection<Employee> employees)
        {
            decimal totalEarnings = 0;
            decimal afp = 0;
            decimal totalPrestamos = 0;
            decimal totalDeductions = 0;
            
            foreach (var item in employees)
            {                
                totalEarnings = item.BaseSalary.Amount;
                afp = totalEarnings * 0.10m;
                if (item.Loans.Count > 0) totalPrestamos = item.Loans.Sum(p => p.Amount.Amount) / item.Loans.Select(x => x.Term.Months).FirstOrDefault();
                totalDeductions = afp + totalPrestamos;
                yield return PayrollDetail.CreateFromIds(payroll.Id, item.Id, $"{item.Name} {item.LastName}", afp, totalEarnings, totalDeductions);
            }                        
        }
    }
}
