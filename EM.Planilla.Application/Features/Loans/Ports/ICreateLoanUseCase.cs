using EM.Planilla.Application.Features.Loans.DTO;
using EM.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Loans.Ports
{
    public interface ICreateLoanUseCase
    {
        Task<Result> ExecuteAsync(CreateLoanRequest request);
    }
}
