using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Api.Application.Features.Queries.GetEntries;

public class GetEntriesQuery: IRequest<List<GetEntriesViewModel>>
{
    public bool EntriesToday { get; set; }
    public int Count { get; set; } = 100;

}

public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, List<GetEntriesViewModel>>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IMapper _mapper;

    public GetEntriesQueryHandler(IEntryRepository entryRepository, IMapper mapper)
    {
        _entryRepository = entryRepository;
        _mapper = mapper;
    }

    public async Task<List<GetEntriesViewModel>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
    {
        var query = _entryRepository.AsQueryable();
        if (request.EntriesToday)
        {
            query = query.Where(i => i.CreateDate >= DateTime.Now.Date)
                .Where(i => i.CreateDate <= DateTime.Now.AddDays(1).Date);
        }

        query.Include(i => i.EntryComments).OrderBy(i=>Guid.NewGuid())
            .Take(request.Count);
        return await query.ProjectTo<GetEntriesViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

    }
}