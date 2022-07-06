namespace BlazorChat.Common.Events.EntryComment;

public class CreateEntryCommentFavEvent
{
    public Guid EntryCommentId { get; set; }
    public Guid CreateBy { get; set; }
}