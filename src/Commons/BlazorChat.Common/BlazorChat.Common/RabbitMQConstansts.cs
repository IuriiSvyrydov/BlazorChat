﻿ 
namespace BlazorChat.Common
{
    public class RabbitMQConstansts
    {
        public const string RabbitMqHost = "localhost";
        public const string DefaultExchangeType = "direct";
        public const string UserExchangeName = "UserExchange";
        public const string UserEmailChangedQueueName = "UserEmailChangedQueue";
    }
}
