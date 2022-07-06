using BlazorChat.Common;
using BlazorChat.Common.Events.EntryFav;
using BlazorChat.Common.Infrastructure;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.Entry.DeleteFav;

public class DeleteEntryFavCommandHandler:IRequestHandler<DeleteEntryFavCommand,bool>
{
    public  Task<bool> Handle(DeleteEntryFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName:RabbitMQConstansts.FavExchangeName,
            exchangeType:RabbitMQConstansts.DefaultExchangeType,
            queueName:RabbitMQConstansts.DeleteEntryFavQueueName,
            obj: new DeleteEntryFavEvent()
            {
                EntryId = request.EntryId,
                CreateBy = request.UserId
            });
        return Task.FromResult(true);
    }
}