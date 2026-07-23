using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Infraestructure.Configuration.Messages
{
    public class RabbitConfiguration
    {
        private readonly RabbitSettings _rabbitSettings;
        private IConnection? _connection;
        public RabbitConfiguration(RabbitSettings rabbitSettings)
        {
            _rabbitSettings = rabbitSettings;
        }
        public async Task<IConnection> GetConnectionAsync()
        {
            if (_connection != null && _connection.IsOpen)
            {
                return _connection;
            }
            var factory = new ConnectionFactory
            {
                HostName = _rabbitSettings.HostName,
                UserName = _rabbitSettings.UserName,
                Password = _rabbitSettings.Password,
            };
            _connection = await factory.CreateConnectionAsync();
            return _connection;
        }
    }
}
