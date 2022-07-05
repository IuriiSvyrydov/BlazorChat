namespace BlazorChat.Api.Domain.Models;

public class EntryComment: BaseEntity
{
#pragma   warning disable
    public string  Content { get; set; }
    public Guid CreateById { get; set; }
    public Guid EntryId { get; set; }
    public virtual User CreateBy{ get; set; }
    public virtual Entry Entry { get; set; }
    public virtual ICollection<EntryCommentVote> EntryCommentVotes { get; set; } = new HashSet<EntryCommentVote>();

    public virtual ICollection<EntryCommentFavorite> EntryCommentFavorites { get; set; } =
        new HashSet<EntryCommentFavorite>();
}