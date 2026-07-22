using EM.Planilla.Domain.Ports.Repositories;
using EM.Planilla.Domain.Ports.Services;
using EM.Planilla.Infraestructure.Adapters.Repositories;
using EM.Planilla.Infraestructure.Adapters.Services;
using EM.Planilla.Infraestructure.Configuration.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlanillaDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DbPlanilla")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
