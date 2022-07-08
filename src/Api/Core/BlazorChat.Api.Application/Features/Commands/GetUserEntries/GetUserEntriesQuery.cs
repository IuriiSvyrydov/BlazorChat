using BlazorChat.Common.Models.Pagination;
using BlazorChat.Common.Models.Queries;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.GetUserEntries;

public class GetUserEntriesQuery: BasePageQuery,IRequest<PageViewModel<GetUserEntriesDetailViewModel>>
{
    public Guid ? UserId { get; set; }
    public string UserName { get; set; }
    public GetUserEntriesQuery( Guid? userId, string userName = null,int page = 1, int pageSize = 10) : base(page, pageSize)
    {
        UserId = userId;
        UserName = userName;
    }
}