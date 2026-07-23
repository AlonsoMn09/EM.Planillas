using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Models.Messages
{
    public class MessageBody
    {
        public string QueueName { get; set; } = default!;
        public object Body { get; set; } = default!;
    }
}
