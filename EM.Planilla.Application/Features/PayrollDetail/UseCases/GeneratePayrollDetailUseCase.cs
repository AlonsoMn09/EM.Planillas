using EM.Planilla.Application.Features.PayrollDetail.Ports;
using EM.Planilla.Application.Results;
using EM.Planilla.Domain.Events.Integration;
using EM.Planilla.Domain.Ports.Repositories;
using EM.Planilla.Domain.Ports.Services;
using EM.Planilla.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.PayrollDetail.UseCases
{
    public class GeneratePayrollDetailUseCase : IGeneratePayrollDetailUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IPayrollRepository _payrollRepository;
        private readonly IPayrollDetailRepository _payrollDetailRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPayrollDetailService _payrollDetailDomainService;
        public GeneratePayrollDetailUseCase(IPayrollRepository payrollRepository
            , IPayrollDetailRepository payrollDetailRepository
            , IUnitOfWork unitOfWork
            , IPayrollDetailService payrollDetailDomainService
            , IEmployeeRepository employeeRepository
            , ILoanRepository loanRepository)
        {
            _payrollRepository = payrollRepository;
            _payrollDetailRepository = payrollDetailRepository;
            _unitOfWork = unitOfWork;
            _payrollDetailDomainService = payrollDetailDomainService;
            _employeeRepository = employeeRepository;
            _loanRepository = loanRepository;
        }
        public async Task<Result> ExecuteAsync(PayrollCreatedIntegrationEvent request)
        {
            var payroll = await _payrollRepository.GetByIdAsync(request.PayrollId);
            if (payroll == null) return Result.Failure($"Payroll with id {request.PayrollId} not found", 404);            
            var employees = await _employeeRepository.ListAsyncQuery(e => e.IsActive, w => w.Loans.Where(p => p.IsActive));
            if (employees.Count == 0) return Result.Failure($"Employees not found", 404);            
            var details = _payrollDetailDomainService.GeneratePayrollDetail(payroll, employees);
            foreach (var item in details)
            {
                await _payrollDetailRepository.AddAsync(item);
            }
            payroll.Completed();
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
    }
}
