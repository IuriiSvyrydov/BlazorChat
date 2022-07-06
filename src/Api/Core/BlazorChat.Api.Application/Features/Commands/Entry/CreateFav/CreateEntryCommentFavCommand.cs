using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.Entry.CreateFav;

public class CreateEntryCommentFavCommand: IRequest<bool>
{
    public CreateEntryCommentFavCommand(Guid entryCommentId, Guid userId)
    {
        EntryCommentId = entryCommentId;
        UserId = userId;
    }

    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }
}