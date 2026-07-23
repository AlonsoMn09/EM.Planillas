using EM.Planilla.Application.Features.Payroll.DTO;
using EM.Planilla.Application.Features.Payroll.Ports;
using EM.Planilla.Application.Results;
using EM.Planilla.Domain.Entities;
using EM.Planilla.Domain.Ports.Repositories;
using EM.Planilla.Domain.Ports.Services;
using EM.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Payroll.UseCases
{
    public class CreatePayrollUseCase : ICreatePayrollUseCase
    {
        private readonly IPayrollRepository _payrollRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePayrollUseCase(IPayrollRepository payrollRepository, IUnitOfWork unitOfWork)
        {
            _payrollRepository = payrollRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> ExecuteAsync(CreatePayrollRequest request)
        {
            var period = Period.Create(request.Month, request.Year);
            var payroll = Domain.Entities.Payroll.Create(period);
            await _payrollRepository.AddAsync(payroll);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Payroll Created Sucessfully");
        }
    }
}
