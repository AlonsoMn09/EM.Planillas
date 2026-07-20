using EM.Planilla.Application.Features.Employee.DTO;
using EM.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Employee.Ports
{
    public interface ICreateEmployeeUseCase
    {
        Task<Result> ExecuteAsync(CreateEmployeeRequest request);
    }
}
