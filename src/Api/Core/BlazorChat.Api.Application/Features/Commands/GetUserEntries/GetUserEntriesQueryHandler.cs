using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Common.Infrastructure.Extensions;
using BlazorChat.Common.Models.Pagination;
using BlazorChat.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Api.Application.Features.Commands.GetUserEntries;

public class GetUserEntriesQueryHandler: IRequestHandler<GetUserEntriesQuery,PageViewModel<GetUserEntriesDetailViewModel>>
{
    private readonly IEntryRepository _entryRepository;

    public GetUserEntriesQueryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task<PageViewModel<GetUserEntriesDetailViewModel>> Handle(GetUserEntriesQuery request, CancellationToken cancellationToken)
    {
        var query = _entryRepository.AsQueryable();
        if (request.UserId!=null && request.UserId.HasValue && request.UserId!=Guid.Empty)
        {
            query = query.Where(i => i.CreateById == request.UserId);
        }

        if (Equals(!string.IsNullOrEmpty(request.UserName)))
        {
            query = query.Where(i => i.CreateBy.UserName == request.UserName);
        }
        else
            return null;

        query = query.Include(i => i.EntryFavorites)
            .Include(i => i.CreateBy);
        var list = query.Select(i => new GetUserEntriesDetailViewModel()
        {
            Id = i.Id,
            Subject = i.Subject,
            Content = i.Content,
            IsFavorited = false,
            FavoritedCount = i.EntryFavorites.Count,
            CreateDate = i.CreateDate,
            CreatedByUserName = i.CreateBy.UserName


        });
        var entries = await list.GetPaged(request.Page, request.PageSize);
        return entries;
    }
}