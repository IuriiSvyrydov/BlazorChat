

namespace BlazorChat.Common.Events.Entry
{
    public class CreateEntryFavEvent
    {
        public Guid EntryId { get; set; }
        public Guid CreateBy { get; set; }
    }
}
