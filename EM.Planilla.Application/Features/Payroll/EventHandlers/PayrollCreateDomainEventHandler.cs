using EM.Planilla.Domain.Events.Domains;
using EM.Planilla.Domain.Events.Integration;
using EM.Planilla.Domain.Ports.Messages;
using EM.Planilla.Domain.Ports.Services;
using EM.Planilla.Domain.Models.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Features.Payroll.EventHandlers
{
    public class PayrollCreateDomainEventHandler : IDomainEventHandler<PayrollCreateDomainEvent>
    {
        private readonly IRabbitProducerService _rabbitProducerService;
        public PayrollCreateDomainEventHandler(IRabbitProducerService rabbitProducerService)
        {
            _rabbitProducerService = rabbitProducerService;
        }
        public async Task HandlerAsync(PayrollCreateDomainEvent domainEvent)
        {
            var payroll = new PayrollCreatedIntegrationEvent(
                    domainEvent.PayrollId
                );
            await _rabbitProducerService.PublisAsync(new MessageBody {
                QueueName = "generate-payroll-detail",
                Body = payroll
            });
        }
    }
}
