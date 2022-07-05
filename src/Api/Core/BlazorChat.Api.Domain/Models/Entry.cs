namespace BlazorChat.Api.Domain.Models;

public class Entry: BaseEntity
{
#pragma warning disable
    public string Subject { get; set; }
    public string Content { get; set; }
    public Guid CreateById { get; set; }
    public User CreateBy { get; set; }
    public ICollection<EntryComment> EntryComments { get; set; } = new HashSet<EntryComment>();
    public ICollection<EntryVote> EntryVotes { get; set; } = new HashSet<EntryVote>();
    public ICollection<EntryFavorite> EntryFavorites { get; set; } = new HashSet<EntryFavorite>();

}