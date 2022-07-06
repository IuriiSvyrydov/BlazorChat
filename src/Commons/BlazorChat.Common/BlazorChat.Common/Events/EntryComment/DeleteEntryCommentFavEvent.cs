namespace BlazorChat.Common.Events.EntryComment;

public class DeleteEntryCommentFavEvent
{
    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }
}