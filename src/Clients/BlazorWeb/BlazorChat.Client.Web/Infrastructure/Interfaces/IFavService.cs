namespace BlazorChat.Client.Web.Infrastructure.Interfaces
{
    public interface IFavService
    {
        Task CreateEntryFav(Guid entryId);
        Task CreateEntryCommentFav(Guid entryCommentId);
        Task DeleteEntryFav(Guid entryId);
        Task DeleteEntryCommentFav(Guid entryCommentId);
    }
}
