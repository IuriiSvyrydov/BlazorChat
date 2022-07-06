using BlazorChat.Common;
using BlazorChat.Common.Events.EntryComment;
using BlazorChat.Common.Infrastructure;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.DeleteFav;

public class DeleteEntryCommentFavCommand: IRequest<bool>
{
    public DeleteEntryCommentFavCommand(Guid entryCommentId, Guid userId)
    {
        EntryCommentId = entryCommentId;
        UserId = userId;
    }

    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }
}
public class DeleteEntryCommentFavCommandHandler: IRequestHandler<DeleteEntryCommentFavCommand,bool>
{
    public async Task<bool> Handle(DeleteEntryCommentFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName:RabbitMQConstansts.FavExchangeName,
            exchangeType:RabbitMQConstansts.DefaultExchangeType,
            queueName:RabbitMQConstansts.DeleteEntryCommentFavQueueName,
            obj: new  DeleteEntryCommentFavEvent()
        {
            UserId = request.UserId,
            EntryCommentId = request.EntryCommentId
        });
        return await Task.FromResult(true);
    }
}
