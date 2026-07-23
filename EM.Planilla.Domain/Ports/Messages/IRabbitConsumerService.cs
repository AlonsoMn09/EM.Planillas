using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Ports.Messages
{
    public interface IRabbitConsumerService
    {
        Task SuscribeAsync<TMessage>(string queueName, Func<IServiceProvider, TMessage, Task> onMessage);
    }
}
