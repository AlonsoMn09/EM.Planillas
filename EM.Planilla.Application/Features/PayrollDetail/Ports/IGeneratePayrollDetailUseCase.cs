using EM.Planilla.Application.Results;
using EM.Planilla.Domain.Events.Integration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.PayrollDetail.Ports
{
    public interface IGeneratePayrollDetailUseCase
    {
        Task<Result> ExecuteAsync(PayrollCreatedIntegrationEvent request);
    }
}
