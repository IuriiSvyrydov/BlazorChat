using BlazorChat.Common.Models;

namespace BlazorChat.Common.Events.EntryComment;

public class CreateEntryCommentVoteEvent
{
    public Guid EntryCommentId { get; set; }
    public VoteType VoteType { get; set; }
    public Guid CreateBy { get; set; }
}