using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.Entry.DeleteVote;

public class DeleteEntryVoteCommand: IRequest<bool>
{
    public Guid EntryId { get; set; }
    public Guid UserId { get; set; }
}