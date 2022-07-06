using MediatR;

namespace BlazorChat.Common.Models.RequestModel;

public class CreateEntryCommand: IRequest<Guid>
{
    public string Subject { get; set; }
    public string Content { get; set; }
    public Guid? CreateById { get; set; }

    public CreateEntryCommand(string subject, string content, Guid? createById)
    {
        Subject = subject;
        Content = content;
        CreateById = createById;
    }
}