using EM.Planilla.Domain.Ports.Messages;
using EM.Planilla.Infraestructure.Configuration.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace EM.Planilla.Infraestructure.Adapters.Messages
{
    public class RabbitConsumerService : IRabbitConsumerService
    {
        private readonly RabbitConfiguration _rabbitConfiguration;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private ILogger<RabbitConsumerService> _logger;
        public RabbitConsumerService(RabbitConfiguration rabbitConfiguration, IServiceScopeFactory serviceScopeFactory, ILogger<RabbitConsumerService> logger)
        {
            _rabbitConfiguration = rabbitConfiguration;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }
        public async Task SuscribeAsync<TMessage>(string queueName, Func<IServiceProvider, TMessage, Task> onMessage)
        {
            var connection = await _rabbitConfiguration.GetConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            var exchange = $"{queueName}.exchange";
            await channel.ExchangeDeclareAsync(exchange, ExchangeType.Direct, durable: true);
            await channel.QueueDeclareAsync(queueName, durable: true, exclusive: false, autoDelete: false);
            await channel.QueueBindAsync(queueName, exchange, routingKey: queueName);
            await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 10, global: false);
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (_, eventArgs) =>
            {
                try
                {
                    var body = eventArgs.Body.ToArray();
                    var message = JsonSerializer.Deserialize<TMessage>(body);
                    using var scope = _serviceScopeFactory.CreateScope();
                    await onMessage(scope.ServiceProvider, message!);
                    await channel.BasicAckAsync(eventArgs.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing message from queue {QueueName}", queueName);
                    await channel.BasicNackAsync(eventArgs.DeliveryTag, false, true);
                }
            };
            await channel.BasicConsumeAsync(queueName, autoAck: false, consumer);
        }
    }
}
