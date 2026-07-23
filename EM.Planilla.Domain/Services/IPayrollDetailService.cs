using EM.Planilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Services
{
    public interface IPayrollDetailService
    {
        IEnumerable<PayrollDetail> GeneratePayrollDetail(Payroll payroll);
    }
}
