using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Payroll.DTO
{
    public class CreatePayrollRequest
    {
        public string Month { get; set; } = default!;
        public string Year { get; set; } = default!;
    }
}
