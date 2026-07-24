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
        private readonly IPayrollRepository _payrollRepository;
        private readonly IPayrollDetailRepository _payrollDetailRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPayrollDetailService _payrollDetailDomainService;
        public GeneratePayrollDetailUseCase(IPayrollRepository payrollRepository, IPayrollDetailRepository payrollDetailRepository, IUnitOfWork unitOfWork, IPayrollDetailService payrollDetailDomainService)
        {
            _payrollRepository = payrollRepository;
            _payrollDetailRepository = payrollDetailRepository;
            _unitOfWork = unitOfWork;
            _payrollDetailDomainService = payrollDetailDomainService;
        }
        public async Task<Result> ExecuteAsync(PayrollCreatedIntegrationEvent request)
        {
            //var payroll = await _payrollRepository.GetByIdAsync(request.PayrollId);
            //if (payroll == null)
            //    return Result.Failure($"Payroll with ID {request.PayrollId} not found", 404);
            //var payrollDetail = _payrollDetailDomainService.GeneratePayrollDetail(payroll);
            //foreach (var item in payrollDetail)
            //{
            //    await _payrollDetailRepository.AddAsync(item);
            //}
            //await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
    }
}
