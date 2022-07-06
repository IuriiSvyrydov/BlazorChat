using BlazorChat.Common;
using BlazorChat.Common.Events.EntryComment;
using BlazorChat.Common.Infrastructure;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.Entry.CreateFav
{
    internal class CreateEntryCommentFavCommandHandler: IRequestHandler<CreateEntryCommentFavCommand,bool>
    {
        public async Task<bool> Handle(CreateEntryCommentFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName:RabbitMQConstansts.FavExchangeName,
                                exchangeType:RabbitMQConstansts.DefaultExchangeType,
                                queueName: RabbitMQConstansts.CreateEntryCommentFavQueueName,
                                obj:new CreateEntryCommentFavEvent()
                                {
                                    EntryCommentId = request.EntryCommentId,
                                    CreateBy = request.UserId
                                });
            return await Task.FromResult(true);
        }
    }
}
