using BlazorChat.Common.Models.Queries;

namespace BlazorChat.Client.Web.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserDetail(Guid? id);
        Task<UserDetailViewModel> GetUserDetail(string userName);
        Task<bool> UpdateUser(UserDetailViewModel user);
        Task<bool> ChangeUserPassword(string oldPassword, string newPassword);
    }
}
