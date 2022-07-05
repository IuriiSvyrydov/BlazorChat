namespace BlazorChat.Api.Domain.Models;

public class EmailConfirmation: BaseEntity
{
#pragma warning disable
    public string OldEmailAddress { get; set; }
    public string NewEmailAddress { get; set; }
    
}