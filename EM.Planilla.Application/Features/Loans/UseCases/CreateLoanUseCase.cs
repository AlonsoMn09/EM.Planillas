using EM.Planilla.Application.Features.Loans.DTO;
using EM.Planilla.Application.Features.Loans.Ports;
using EM.Planilla.Application.Results;
using EM.Planilla.Domain.Entities;
using EM.Planilla.Domain.Ports.Repositories;
using EM.Planilla.Domain.Ports.Services;
using EM.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Loans.UseCases
{
    public class CreateLoanUseCase : ICreateLoanUseCase
    {
        private ILoanRepository _loanRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        public CreateLoanUseCase(ILoanRepository loanRepository, IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
        {
            _loanRepository = loanRepository;
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }

        public async Task<Result> ExecuteAsync(CreateLoanRequest request)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
            if (employee == null)
            {
                return Result.Failure($"Employee with ID {request.EmployeeId} not found.", 404);
            }
            var amount = Money.Create(request.Currency, request.Amount);
            var term = LoanTerm.Create(request.TermMonths);            
            var loan = Loan.Create(amount, term, employee);
            await _loanRepository.AddAsync(loan);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Loan created successfully.");
        }
    }
}
