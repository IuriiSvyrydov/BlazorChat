using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BlazorChat.Common.Infrastructure;

public static class QueueFactory
{
    public static void SendMessageToExchange(string exchangeName,
        string exchangeType,
        string queueName,
        object obj)
    {
      var chanel  =    CreateBasicConsumer().EnsureExchange(exchangeName, exchangeType)
            .EnsureQueue(queueName,exchangeName).Model;
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));
        chanel.BasicPublish(exchange:exchangeName,
                            routingKey:queueName,
                            basicProperties: null,
                            body:body);
    }


    public static EventingBasicConsumer CreateBasicConsumer()
    {
        var factory = new ConnectionFactory()
        {
            HostName = RabbitMQConstansts.RabbitMqHost
        };
        var connection = factory.CreateConnection();
        var chanel = connection.CreateModel();
        return new EventingBasicConsumer(chanel);
    }

    public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consumer,
        string exchangeName,
        string exchangeType = RabbitMQConstansts.DefaultExchangeType)
    {
        consumer.Model.ExchangeDeclare(exchange:exchangeName,type:exchangeType,durable:false,autoDelete:false);
        return consumer;
    }
    public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consumer,
        string queueName,
        string exchangeName)
    {
        consumer.Model.QueueDeclare(queue: queueName, durable: false,
            exclusive: false, autoDelete: false, null);
        consumer.Model.QueueBind(queueName,exchangeName,queueName);
       
        return consumer;
    }
}   