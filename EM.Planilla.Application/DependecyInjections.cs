using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EM.Planilla.Domain;
using EM.Planilla.Application.Features.Employee.Ports;
using EM.Planilla.Application.Features.Employee.UseCases;
using EM.Planilla.Application.Features.Loans.Ports;
using EM.Planilla.Application.Features.Loans.UseCases;

namespace EM.Planilla.Application
{
    public static class DependecyInjections
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateEmployeeUseCase, CreateEmployeeUseCase>();
            services.AddScoped<IListEmployeeUseCase, ListEmployeeUseCase>();
            services.AddScoped<ICreateLoanUseCase, CreateLoanUseCase>();
            services.AddScoped<EmployeeUseCases>();
            services.AddScoped<LoanUseCases>();
            return services;
        }
    }
}
