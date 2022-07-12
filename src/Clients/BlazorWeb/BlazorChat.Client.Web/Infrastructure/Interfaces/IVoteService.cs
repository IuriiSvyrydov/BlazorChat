using BlazorChat.Common.Models;

namespace BlazorChat.Client.Web.Infrastructure.Interfaces
{
    public interface IVoteService
    {
        Task<HttpResponseMessage> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote);
        Task DeleteEntryVote(Guid entryId);
        Task DeleteEntryCommentVote(Guid entryCommentId);
        Task CreateEntryUpVote(Guid entryId);
        Task CreateEntryDownVote(Guid entryId);
        Task CreateEntryCommentUpVote(Guid entryCommentId);
        Task CreateEntryCommentDownVote(Guid entryCommentId);
    }
}
