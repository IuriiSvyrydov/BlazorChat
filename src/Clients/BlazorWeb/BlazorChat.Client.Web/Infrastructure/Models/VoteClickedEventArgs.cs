namespace BlazorChat.Client.Web.Infrastructure.Models
{
    public class VoteClickedEventArgs: EventArgs
    {
        public  Guid EntryId { get; set; }
        public bool IsDownVoteClicked { get; set; }
        public bool UpVoteDeleted { get; set; }
        public bool DownVoteDeleted { get; set; }
        public bool IsUpVoteClicked { get; set; }
    }
}
