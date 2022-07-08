using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Api.Application.Features.Commands.SearchBySubject;

public class SearchEntryQueryHandler: IRequestHandler<SearchEntryQuery,List<SearchEntryViewModel>>
{
    private readonly  IEntryRepository _entryRepository;

    public SearchEntryQueryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task<List<SearchEntryViewModel>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
    {
        _entryRepository.Get(i => i.Subject.StartsWith(""));
        var result = _entryRepository.Get(i => EF.Functions
            .Like(i.Subject, $"{request.SearchText}%"))
            .Select(i=>new SearchEntryViewModel()
            {
                Id = i.Id,
                Subject = i.Subject
            });
        return await result.ToListAsync(cancellationToken);

    }
}