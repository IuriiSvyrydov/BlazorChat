using BlazorChat.Common;
using BlazorChat.Common.Events.Entry;
using BlazorChat.Common.Infrastructure;
using BlazorChat.Common.Models.RequestModel;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.Entry.CreateVote;

public class CreateEntryVoteCommandHandler: IRequestHandler<CreateEntryVoteCommand,bool>
{
    public  Task<bool> Handle(CreateEntryVoteCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName:RabbitMQConstansts.VoteExchangeName,
            exchangeType:RabbitMQConstansts.DefaultExchangeType,
            queueName:RabbitMQConstansts.CreateEntryVoteQueueName,
            obj:  new CreateEntryVoteEvent
            {
                EntryId = request.EntryId,
                CreateBy = request.CreateBy,
                VoteType = request.VoteType
            });
        return Task.FromResult(true);
    }
}