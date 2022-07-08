namespace BlazorChat.Common.Models.Queries;

public class GetEntryDetailViewModel: BaseFooterRateViewModel
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedByUserName { get; set; }
    //public bool IsFavorited { get; set; }
    //public int FavoritedCount { get; set; }
    //public VoteType VoteType { get; set; }
}