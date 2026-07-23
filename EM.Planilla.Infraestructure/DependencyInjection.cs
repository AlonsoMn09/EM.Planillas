using EM.Planilla.Domain.Ports.Messages;
using EM.Planilla.Domain.Ports.Repositories;
using EM.Planilla.Domain.Ports.Services;
using EM.Planilla.Domain.Services;
using EM.Planilla.Infraestructure.Adapters.Messages;
using EM.Planilla.Infraestructure.Adapters.Repositories;
using EM.Planilla.Infraestructure.Adapters.Services;
using EM.Planilla.Infraestructure.Configuration.Messages;
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
            services.AddScoped<IPayrollRepository, PayrollRepository>();
            services.AddScoped<IPayrollDetailRepository, PayrollDetailRepository>();
            services.AddScoped<IPayrollDetailService, PayrollDetailService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DomainEventDispatcher>();

            var rabbitSettings = configuration.GetSection("RabbitSettings").Get<RabbitSettings>();
            if (rabbitSettings is null) throw new InvalidDataException("RabbitSettings configuration is missing or invalid.");
            services.AddSingleton(rabbitSettings);
            services.AddSingleton<RabbitConfiguration>();
            services.AddScoped<IRabbitProducerService, RabbitProducerService>();
            services.AddScoped<IRabbitConsumerService, RabbitConsumerService>();
            return services;
        }
    }
}
