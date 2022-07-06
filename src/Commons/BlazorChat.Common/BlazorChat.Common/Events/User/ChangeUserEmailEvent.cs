namespace BlazorChat.Common.Events.User;

public class ChangeUserEmailEvent
{
    public string OldEmailAddress { get; set; }
    public string NewEmailAddress { get; set; }
}