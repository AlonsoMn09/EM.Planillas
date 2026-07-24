using EM.Planilla.Application.Features.PayrollDetail.Ports;
using EM.Planilla.Domain.Events.Integration;
using EM.Planilla.Domain.Ports.Messages;

namespace EM.Planilla.Worker
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<Worker> _logger;
        public Worker(IServiceScopeFactory serviceScopeFactory, ILogger<Worker> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var consumer = scope.ServiceProvider.GetRequiredService<IRabbitConsumerService>();
            await consumer.SuscribeAsync<PayrollCreatedIntegrationEvent>(
                "generate-payroll-detail",
                async (sp, message) =>
                {
                    var useCase = sp.GetRequiredService<IGeneratePayrollDetailUseCase>();
                    await useCase.ExecuteAsync(message);
                });
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
