using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Employee.DTO
{
    public class CreateEmployeeRequest
    {
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string DocumentType { get; set; } = default!;
        public string DocumentNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
