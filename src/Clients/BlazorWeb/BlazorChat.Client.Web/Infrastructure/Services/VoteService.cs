using BlazorChat.Client.Web.Infrastructure.Interfaces;
using BlazorChat.Common.Models;

namespace BlazorChat.Client.Web.Infrastructure.Services
{
    public class VoteService : IVoteService
    {
        private readonly HttpClient _httpClient;

        public VoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteEntryVote(Guid entryId)
        {
           var response = await _httpClient.PutAsync($"/api/Vote/DeleteEntryVote/{entryId}", null);
           if (!response.IsSuccessStatusCode)
               throw new Exception("DeleteEntryVote error");
        }
        public async Task DeleteEntryCommentVote(Guid entryCommentId)
        {
            var response = await _httpClient.PutAsync($"/api/Vote/DeleteEntryCommentVote/{entryCommentId}", null);
            if (!response.IsSuccessStatusCode)
                throw new Exception("DeleteEntryCommentVote error");
        }

        public async Task CreateEntryUpVote(Guid entryId)
        {
            await CreateEntryVote(entryId, VoteType.UpVote);
        }
        public async Task CreateEntryDownVote(Guid entryId)
        {
            await CreateEntryVote(entryId, VoteType.DownVote);
        }
        public async Task CreateEntryCommentUpVote(Guid entryCommentId)
        {
            await CreateEntryCommentVote(entryCommentId, VoteType.DownVote);
        }
        public async Task CreateEntryCommentDownVote(Guid entryCommentId)
        {
            await CreateEntryCommentVote(entryCommentId, VoteType.DownVote);
        }

        private async Task<HttpResponseMessage> CreateEntryVote(Guid entryId,VoteType voteType =VoteType.UpVote )
        {
            var result = await _httpClient.PostAsync($"/api/vote/entry/{entryId}?voteType={voteType}", null);
            //TODO check success

            return result;
        }
        private async Task<HttpResponseMessage> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
        {
            var result = await _httpClient.PostAsync($"/api/vote/entryComment/{entryCommentId}?voteType={voteType}", null);
            //TODO check success

            return result;
        }
    }
}
