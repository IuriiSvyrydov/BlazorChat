namespace BlazorChat.Api.Domain.Models;

public class EntryFavorite: BaseEntity
{
#pragma warning disable
    public Guid EntryId { get; set; }
    public Guid CreateById { get; set; }
    public virtual Entry Entry { get; set; }
    public virtual User CreateUser{ get; set; }
}