using AutoMapper;
using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Common.Infrastructure.Extensions;
using BlazorChat.Common.Models;
using BlazorChat.Common.Models.Pagination;
using BlazorChat.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Api.Application.Features.Commands.GetMainPageEntitites;

public class GetMainPageEntriesQuery: BasePageQuery,IRequest<PageViewModel<GetEntryDetailViewModel>>
{
    public GetMainPageEntriesQuery(Guid?userId, int page, int pageSize) : base(page, pageSize)
    {
        UserId = userId;
    }

    public Guid? UserId { get; set; }
}

public class GetMainPageEntriesQueryHandler : IRequestHandler<GetMainPageEntriesQuery,PageViewModel<GetEntryDetailViewModel>>
{
    private readonly IEntryRepository _entryRepository;
  
    public GetMainPageEntriesQueryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
  
    }

    public async Task<PageViewModel<GetEntryDetailViewModel>> Handle(GetMainPageEntriesQuery request, CancellationToken cancellationToken)
    {
        var query = _entryRepository.AsQueryable();
        query = query.Include(i => i.EntryComments)
            .Include(i => i.CreateBy)
            .Include(i=>i.EntryVotes);
        var list = query.Select(i => new GetEntryDetailViewModel()
        {
            Id = i.Id,
            Subject = i.Subject,
            Content = i.Content,
            IsFavorited = request.UserId.HasValue && i.EntryFavorites
                .Any(j=>j.CreateById==request.UserId),
            FavoritedCount = i.EntryFavorites.Count,
            CreatedDate = i.CreateDate,
            CreatedByUserName = i.CreateBy.UserName,
            VoteType = request.UserId.HasValue && i.EntryVotes
                .Any(j => j.CreateById == request.UserId) ? i.EntryVotes.FirstOrDefault(x=>x.CreateById==request.UserId)
                .VoteType :VoteType.None


        });
        var entities = await list.GetPaged(request.Page, request.PageSize);
        return new PageViewModel<GetEntryDetailViewModel>(entities.Results, entities.PageInfo);
    }
}