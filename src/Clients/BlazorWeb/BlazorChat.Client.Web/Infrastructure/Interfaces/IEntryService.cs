using BlazorChat.Common.Models.Pagination;
using BlazorChat.Common.Models.Queries;
using BlazorChat.Common.Models.RequestModel;

namespace BlazorChat.Client.Web.Infrastructure.Interfaces
{
    public interface IEntryService
    {
        Task<List<GetEntriesViewModel>> GetEntries();
        Task<GetEntryDetailViewModel> GetEntryDetail(Guid entryId);
        Task<PageViewModel<GetEntryDetailViewModel>> GetMainPageEntries(int page, int pageSize);

        Task<PageViewModel<GetEntryDetailViewModel>> GetProfilePageEntries(int page, int pageSize,
            string userName = null);

        Task<PageViewModel<GetEntryCommentsViewModel>> GetEntryComments(Guid entryId, int page, int pageSize);
        Task<Guid> CreateEntry(CreateEntryCommand command);
        Task<Guid> CreateEntryComment(CreateEntryCommentCommand command);
        Task<List<SearchEntryViewModel>> SearchBySubject(string searchText);
    }
}
