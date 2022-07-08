using BlazorChat.Common.Models.Pagination;
using BlazorChat.Common.Models.Queries;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.GetMainPageEntitites;

public class GetMainPageEntriesQuery: BasePageQuery,IRequest<PageViewModel<GetEntryDetailViewModel>>
{
    public GetMainPageEntriesQuery(Guid?userId, int page, int pageSize) : base(page, pageSize)
    {
        UserId = userId;
    }

    public Guid? UserId { get; set; }
}
