using EM.Planilla.Domain.Entities;
using EM.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Services
{
    public interface IPayrollDetailService
    {
        IEnumerable<PayrollDetail> GeneratePayrollDetail(Payroll payroll, ICollection<Employee> employees);
    }
}
