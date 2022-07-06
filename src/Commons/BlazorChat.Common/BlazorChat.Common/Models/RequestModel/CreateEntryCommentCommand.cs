using MediatR;

namespace BlazorChat.Common.Models.RequestModel;

public class CreateEntryCommentCommand: IRequest<Guid>
{
    public CreateEntryCommentCommand(Guid entryId, string content, Guid createById)
    {
        EntryId = entryId;
        Content = content;
        CreateById = createById;
    }

    public CreateEntryCommentCommand()
    {
        
    }
    public Guid? EntryId { get; set; }
    public string Content { get; set; }
    public Guid? CreateById { get; set; }
}