using EM.Planilla.Application.Features.Employee.Ports;
using EM.Planilla.Application.Features.Employee.UseCases;
using EM.Planilla.Application.Features.Loans.Ports;
using EM.Planilla.Application.Features.Loans.UseCases;
using EM.Planilla.Application.Features.Payroll.EventHandlers;
using EM.Planilla.Application.Features.Payroll.Ports;
using EM.Planilla.Application.Features.Payroll.UseCases;
using EM.Planilla.Application.Features.PayrollDetail.Ports;
using EM.Planilla.Application.Features.PayrollDetail.UseCases;
using EM.Planilla.Domain;
using EM.Planilla.Domain.Events.Domains;
using EM.Planilla.Domain.Ports.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application
{
    public static class DependecyInjections
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateEmployeeUseCase, CreateEmployeeUseCase>();
            services.AddScoped<IListEmployeeUseCase, ListEmployeeUseCase>();
            services.AddScoped<ICreateLoanUseCase, CreateLoanUseCase>();
            services.AddScoped<ICreatePayrollUseCase, CreatePayrollUseCase>();
            services.AddScoped<IGeneratePayrollDetailUseCase, GeneratePayrollDetailUseCase>();
            services.AddScoped<EmployeeUseCases>();
            services.AddScoped<LoanUseCases>();
            services.AddScoped<PayrollUseCases>();

            services.AddScoped<IDomainEventHandler<PayrollCreateDomainEvent>, PayrollCreateDomainEventHandler>();
            return services;
        }
    }
}
