using EM.Planilla.Domain.Models.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Ports.Messages
{
    public interface IRabbitProducerService
    {
        Task PublisAsync(MessageBody request);
    }
}
