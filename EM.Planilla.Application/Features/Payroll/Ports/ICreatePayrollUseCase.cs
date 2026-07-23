using EM.Planilla.Application.Features.Payroll.DTO;
using EM.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Payroll.Ports
{
    public interface ICreatePayrollUseCase
    {
        Task<Result> ExecuteAsync(CreatePayrollRequest request);
    }
}
