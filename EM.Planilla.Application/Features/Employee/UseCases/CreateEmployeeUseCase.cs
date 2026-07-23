using EM.Planilla.Application.Features.Employee.DTO;
using EM.Planilla.Application.Features.Employee.Ports;
using EM.Planilla.Application.Results;
using EM.Planilla.Domain.Entities;
using EM.Planilla.Domain.Ports.Repositories;
using EM.Planilla.Domain.Ports.Services;
using EM.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Employee.UseCases
{
    public class CreateEmployeeUseCase : ICreateEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmployeeUseCase(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> ExecuteAsync(CreateEmployeeRequest request)
        {
            var exisitngEmployee = await _employeeRepository.FindAsync(p => p.Document.Number == request.DocumentNumber && p.Document.Type == request.DocumentType);
            if (exisitngEmployee != null)
            {
                return Result.Failure("Employee with the same document number already exists.");
            }
            var existingEmployeeByEmail = await _employeeRepository.FindAsync(p => p.Email == request.Email);
            if (existingEmployeeByEmail != null)
            {
                return Result.Failure("Employee with the same email already exists.");
            }
            var document = IdentityDocument.Create(request.DocumentType, request.DocumentNumber);
            var salary = Money.Create(request.SalaryCurrency, request.SalaryAmount);
            var employee = EM.Planilla.Domain.Entities.Employee.Create(request.Name, request.LastName, document, request.Email, request.HireDate, salary);
            await _employeeRepository.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Employee created successfully.");
        }
    }
}
