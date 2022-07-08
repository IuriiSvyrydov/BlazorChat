

namespace BlazorChat.Common.Models.Queries
{
    public class GetEntryCommentsViewModel: BaseFooterFavoritedViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public VoteType VoteType { get; set; }
    }
}
