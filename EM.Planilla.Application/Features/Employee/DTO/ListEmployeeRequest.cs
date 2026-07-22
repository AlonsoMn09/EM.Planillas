using EM.Planilla.Application.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Employee.DTO
{
    public class ListEmployeeRequest : PagedRequest
    {
        public string Filter { get; set; } = string.Empty;
    }
}
