using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Common.Infrastructure.Extensions;
using BlazorChat.Common.Models;
using BlazorChat.Common.Models.Pagination;
using BlazorChat.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Api.Application.Features.Queries.EntryComments;

public class GetEntryCommentQueryHandler: IRequestHandler<GetEntryCommentQuery, PageViewModel<GetEntryCommentsViewModel>>
{
    private readonly IEntryCommentRepository _entryCommentRepository;

    public GetEntryCommentQueryHandler( IEntryCommentRepository entryCommentRepository)
    {
        _entryCommentRepository = entryCommentRepository;
    }

    public async Task<PageViewModel<GetEntryCommentsViewModel>> Handle(GetEntryCommentQuery request, 
        CancellationToken cancellationToken)
    {
    var query = _entryCommentRepository.AsQueryable();
    query = query
        .Include(i => i.EntryCommentFavorites)
    .    Include(i => i.CreateBy)
        .Include(i => i.EntryCommentVotes)
    .Where(i=>i.EntryId==request.UserId);
    var list = query.Select(i => new GetEntryCommentsViewModel()
    {
        Id = i.Id,
        Content = i.Content,
        IsFavorited = request.UserId.HasValue && i.EntryCommentFavorites
            .Any(j => j.CreateById == request.UserId),
        FavoritedCount = i.EntryCommentFavorites.Count,
        CreatedDate = i.CreateDate,
        CreatedByUserName = i.CreateBy.UserName,
        VoteType = request.UserId.HasValue && i.EntryCommentVotes
            .Any(j => j.CreateById == request.UserId) ? i.EntryCommentVotes.FirstOrDefault(x => x.CreateById == request.UserId)
            .VoteType : VoteType.None


    });
    var entities = await list.GetPaged(request.Page, request.PageSize);
    return entities;

    }
}