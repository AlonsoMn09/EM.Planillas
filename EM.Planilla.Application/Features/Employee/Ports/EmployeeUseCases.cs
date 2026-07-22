using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Employee.Ports
{
    public record EmployeeUseCases
        (
            ICreateEmployeeUseCase create,
            IListEmployeeUseCase list
        );
}
