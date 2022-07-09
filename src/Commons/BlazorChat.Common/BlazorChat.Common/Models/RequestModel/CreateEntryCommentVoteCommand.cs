using MediatR;

namespace BlazorChat.Common.Models.RequestModel;

public class CreateEntryCommentVoteCommand: IRequest<bool>
{

    public CreateEntryCommentVoteCommand()
    {
        
    }
    public CreateEntryCommentVoteCommand(Guid entryCommentId, VoteType voteType, Guid createBy)
    {
        EntryCommentId = entryCommentId;
        VoteType = voteType;
        CreateBy = createBy;
        
    }

    public Guid EntryCommentId { get; set; }
    public VoteType VoteType { get; set; }
    public Guid CreateBy { get; set; }

    
}