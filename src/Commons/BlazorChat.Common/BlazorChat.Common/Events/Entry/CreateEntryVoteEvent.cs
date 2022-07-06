using BlazorChat.Common.Models;

namespace BlazorChat.Common.Events.Entry;

public class CreateEntryVoteEvent
{
    public Guid EntryId { get; set; }
    public Guid CreateBy { get; set; }
    public VoteType VoteType { get; set; }
}