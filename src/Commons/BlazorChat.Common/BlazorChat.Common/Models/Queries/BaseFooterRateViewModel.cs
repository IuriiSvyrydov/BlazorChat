namespace BlazorChat.Common.Models.Queries;

public class BaseFooterRateViewModel:BaseFooterFavoritedViewModel
{
    public VoteType VoteType { get; set; }
}

public class BaseFooterFavoritedViewModel
{
    public bool IsFavorited { get; set; }
    public int FavoritedCount { get; set; }
}