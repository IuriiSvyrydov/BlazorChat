using System.Net;
using BlazorChat.Common.Models.Queries;
using MediatR;

namespace BlazorChat.Common.Models.RequestModel;

public class LoginUserCommand: IRequest<LoginUserViewModel>
{
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public LoginUserCommand()
    {
        
    }

    public LoginUserCommand(string emailAddress,string password)
    {
        EmailAddress = emailAddress;
        Password = password;
    }
}