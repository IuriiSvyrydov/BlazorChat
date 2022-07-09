using BlazorChat.Common.Models.RequestModel;

namespace BlazorChat.Client.Web.Infrastructure.Interfaces
{
    public interface IIdentityService
    {
        bool IsLoggedIn { get; }
        string GetUserToken();
        string GetUserName();
        Guid GetUserId();
        Task<bool> Login(LoginUserCommand command);
        void Logout();
    }
}
