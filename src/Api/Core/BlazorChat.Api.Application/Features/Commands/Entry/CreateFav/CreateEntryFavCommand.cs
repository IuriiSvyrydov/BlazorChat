using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.Entry.CreateFav;

public class CreateEntryFavCommand: IRequest<bool>
{
    public Guid? EntryId { get; set; }
    public Guid? UserId { get; set; }
}