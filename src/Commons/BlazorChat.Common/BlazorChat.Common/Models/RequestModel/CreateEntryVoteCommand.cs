using MediatR;

namespace BlazorChat.Common.Models.RequestModel;

public class CreateEntryVoteCommand: IRequest<bool>
{
    public Guid EntryId  { get; set; }
    public Guid CreateBy { get; set; }
    public VoteType VoteType { get; set; }
}