

using BlazorChat.Common;
using BlazorChat.Common.Events.Entry;
using BlazorChat.Common.Infrastructure;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEntryFavCommandHandler: IRequestHandler<CreateEntryFavCommand,bool>
    {

        public  Task<bool> Handle(CreateEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName:RabbitMQConstansts.FavExchangeName,
                                exchangeType:RabbitMQConstansts.DefaultExchangeType,
                                queueName: RabbitMQConstansts.CreateEntryFavQueueName,
                                obj: new CreateEntryFavEvent
                                {
                                    EntryId = request.EntryId.Value,
                                    CreateBy = request.UserId.Value

                                });
            return Task.FromResult(true);
        }
    }
}
