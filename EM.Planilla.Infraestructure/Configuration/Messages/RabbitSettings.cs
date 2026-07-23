using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Infraestructure.Configuration.Messages
{
    public class RabbitSettings
    {
        public string HostName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
