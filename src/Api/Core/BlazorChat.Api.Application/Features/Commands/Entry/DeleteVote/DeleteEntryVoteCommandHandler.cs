using BlazorChat.Common;
using BlazorChat.Common.Events.EntryFav;
using BlazorChat.Common.Infrastructure;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.Entry.DeleteVote;

public class DeleteEntryVoteCommandHandler: IRequestHandler<DeleteEntryVoteCommand,bool>
{
    public async Task<bool> Handle(DeleteEntryVoteCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName:RabbitMQConstansts.VoteExchangeName,
                                            exchangeType:RabbitMQConstansts.DefaultExchangeType,
                                            queueName:RabbitMQConstansts.DeleteEntryVoteQueueName,
                                            obj: new DeleteEntryFavEvent()
                                            {
                                                EntryId = request.EntryId,
                                                CreateBy = request.UserId
                                            });
        return await Task.FromResult(true);
    }
}