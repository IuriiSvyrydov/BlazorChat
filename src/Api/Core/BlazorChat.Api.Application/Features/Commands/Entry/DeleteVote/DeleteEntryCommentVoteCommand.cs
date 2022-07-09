using BlazorChat.Common;
using BlazorChat.Common.Events.EntryComment;
using BlazorChat.Common.Infrastructure;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.Entry.DeleteVote;

public class DeleteEntryCommentVoteCommand: IRequest<bool>
{
    public DeleteEntryCommentVoteCommand(Guid entryCommentId, Guid userId)
    {
        EntryCommentId = entryCommentId;
        UserId = userId;
    }

    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }

}
public class DeleteEntryCommentVoteCommandHandler : IRequestHandler<DeleteEntryCommentVoteCommand, bool>
{
    public async Task<bool> Handle(DeleteEntryCommentVoteCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: RabbitMQConstansts.VoteExchangeName,
            exchangeType: RabbitMQConstansts.DefaultExchangeType,
            queueName: RabbitMQConstansts.DeleteEntryCommentVoteQueueName,
            obj: new DeleteEntryCommentVoteEvent()
            {
                EntryCommentId = request.EntryCommentId,
                CreateBy = request.UserId
            });
        return await Task.FromResult(true);
    }
}
