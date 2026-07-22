using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Loans.DTO
{
    public class CreateLoanRequest
    {
        public Guid EmployeeId { get; set; }
        public string Currency { get; set; } = default!;
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
    }
}
