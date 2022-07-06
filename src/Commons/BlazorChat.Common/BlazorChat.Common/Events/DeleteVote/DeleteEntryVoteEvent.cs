namespace BlazorChat.Common.Events.DeleteVote;

public class DeleteEntryVoteEvent
{
    public Guid EntryId { get; set; }
    public Guid CreateBy { get; set; }
}