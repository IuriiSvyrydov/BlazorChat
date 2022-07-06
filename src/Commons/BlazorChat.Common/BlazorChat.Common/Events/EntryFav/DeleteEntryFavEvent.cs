namespace BlazorChat.Common.Events.EntryFav;

public class DeleteEntryFavEvent
{
    public Guid EntryId { get; set; }
    public Guid CreateBy { get; set; }
}