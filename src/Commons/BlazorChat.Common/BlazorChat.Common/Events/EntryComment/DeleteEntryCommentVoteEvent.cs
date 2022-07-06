
namespace BlazorChat.Common.Events.EntryComment
{
    public class DeleteEntryCommentVoteEvent
    {

        public Guid EntryCommentId { get; set; }
        public Guid CreateBy { get; set; }

    }
}
