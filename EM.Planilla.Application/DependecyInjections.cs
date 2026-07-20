using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EM.Planilla.Domain;
using EM.Planilla.Application.Features.Employee.Ports;
using EM.Planilla.Application.Features.Employee.UseCases;

namespace EM.Planilla.Application
{
    public static class DependecyInjections
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateEmployeeUseCase, CreateEmployeeUseCase>();
            services.AddScoped<EmployeeUseCases>();
            return services;
        }
    }
}
