using BlazorChat.Common.ViewModels;

namespace BlazorChat.Api.Domain.Models;

public class EntryCommentVote: BaseEntity
{
    public Guid EntryCommentId { get; set; }
    public VoteType  VoteType { get; set; }
    public Guid CreateById { get; set; }
    public virtual EntryComment EntryComment{ get; set; }
}