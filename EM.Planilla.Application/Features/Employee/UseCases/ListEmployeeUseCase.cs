using EM.Planilla.Application.Features.Employee.DTO;
using EM.Planilla.Application.Features.Employee.Ports;
using EM.Planilla.Application.Results;
using EM.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Employee.UseCases
{
    public class ListEmployeeUseCase : IListEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public ListEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<List<ListEmployeeResponse>>> ExecuteAsync(ListEmployeeRequest request)
        {
            var result = await _employeeRepository.ListAsync
                (
                    predicate: p =>
                        (string.IsNullOrWhiteSpace(request.Filter) || p.Name.ToUpper().Contains(request.Filter.ToUpper())) ||
                        (string.IsNullOrWhiteSpace(request.Filter) || p.LastName.ToUpper().Contains(request.Filter.ToUpper())) ||
                        (string.IsNullOrEmpty(request.Filter) || p.Document.Number.Contains(request.Filter.ToUpper())),
                    selector: p => new ListEmployeeResponse
                    {
                        Name = p.Name,
                        LastName = p.LastName,
                        DocumentType = p.Document.Type.ToString(),
                        DocumentNumber = p.Document.Number,
                        Email = p.Email,
                        HireDate = p.HireDate,
                        Currency = p.BaseSalary.Currency!.ToString(),
                        Amount = p.BaseSalary.Amount,
                        CreatedAt = p.CreatedAt
                    },
                    pageNumber: request.PageNumber,
                    pageSize: request.PageSize
                );
            return Result<List<ListEmployeeResponse>>.Success(result.Result.ToList());
        }
    }
}
