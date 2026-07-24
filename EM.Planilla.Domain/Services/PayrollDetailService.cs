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
        public IEnumerable<PayrollDetail> GeneratePayrollDetail(Payroll payroll, Employee employee, decimal totalEarnings, decimal totalDeductions)
        {
            yield return PayrollDetail.Create(payroll, employee, totalEarnings, totalDeductions);
        }
    }
}
