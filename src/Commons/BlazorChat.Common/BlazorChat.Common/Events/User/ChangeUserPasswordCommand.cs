using MediatR;

namespace BlazorChat.Common.Events.User;

public class ChangeUserPasswordCommand: IRequest<bool>
{
    public ChangeUserPasswordCommand(Guid userId, string oldPassword, string password)
    {
        UserId = userId;
        OldPassword = oldPassword;
        NewPassword = password;
    }

    public Guid? UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}