using BlazorChat.Common.Models.Pagination;
using BlazorChat.Common.Models.Queries;
using MediatR;


namespace BlazorChat.Api.Application.Features.Queries.EntryComments;

public class GetEntryCommentQuery: BasePageQuery,IRequest<PageViewModel<GetEntryCommentsViewModel>>
{
    public GetEntryCommentQuery(Guid? entryId, Guid? userId ,int page, int pageSize ) : base(page, pageSize)
    {
        EntryId = entryId;
        UserId = userId;
    }

    public Guid? EntryId { get; set; }
    public Guid? UserId { get; set; }
}