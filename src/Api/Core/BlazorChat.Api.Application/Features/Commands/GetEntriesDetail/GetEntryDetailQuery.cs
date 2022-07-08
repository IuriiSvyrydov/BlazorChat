using BlazorChat.Common.Models.Queries;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.GetEntriesDetail;

public class GetEntryDetailQuery: IRequest<GetEntryDetailViewModel>
{
    public GetEntryDetailQuery(Guid entryId, Guid? userId)
    {
        EntryId = entryId;
        UserId = userId;
    }

    public Guid EntryId { get; set; }
    public Guid ?UserId { get; set; }
}