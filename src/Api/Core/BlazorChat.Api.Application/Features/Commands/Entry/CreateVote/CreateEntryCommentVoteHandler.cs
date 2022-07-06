using BlazorChat.Common;
using BlazorChat.Common.Events.EntryComment;
using BlazorChat.Common.Infrastructure;
using BlazorChat.Common.Models.RequestModel;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.Entry.CreateVote;

public class CreateEntryCommentVoteHandler: IRequestHandler<CreateEntryCommentVoteCommand,bool>
{
    public async Task<bool> Handle(CreateEntryCommentVoteCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: RabbitMQConstansts.VoteExchangeName,
            exchangeType: RabbitMQConstansts.DefaultExchangeType,
            queueName: RabbitMQConstansts.CreateEntryCommentVoteQueueName,
            obj: new CreateEntryCommentVoteEvent()
            {
                EntryCommentId = request.EntryCommentId,
                CreateBy = request.CreateBy,
                VoteType = request.VoteType,
                
            });
        return await Task.FromResult(true);
    }
}