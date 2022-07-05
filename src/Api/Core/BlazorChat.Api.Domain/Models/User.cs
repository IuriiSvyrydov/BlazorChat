namespace BlazorChat.Api.Domain.Models;

public class User: BaseEntity
{
#pragma warning disable
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool EmailConfirmed { get; set; }
    public virtual ICollection<Entry> Entries { get; set; } = new HashSet<Entry>();
    public virtual ICollection<EntryFavorite> EntryFavorites { get; set; } = new HashSet<EntryFavorite>();
    public virtual ICollection<EntryComment> EntryComments { get; set; } = new HashSet<EntryComment>();

    public virtual ICollection<EntryCommentFavorite> EntryCommentFavorites { get; set; } =
        new HashSet<EntryCommentFavorite>();
}