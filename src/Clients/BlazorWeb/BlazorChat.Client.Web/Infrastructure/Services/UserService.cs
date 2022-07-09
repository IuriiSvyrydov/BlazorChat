using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using BlazorChat.Client.Web.Infrastructure.Interfaces;
using BlazorChat.Common.Events.User;
using BlazorChat.Common.Exceptions;
using BlazorChat.Common.Infrastructure.Results;
using BlazorChat.Common.Models.Queries;

namespace BlazorChat.Client.Web.Infrastructure.Services
{
    public class UserService: IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserDetail(Guid? id)
        {
            var userDetail = await _httpClient.GetFromJsonAsync<UserDetailViewModel>($"/api/user/{id}");
            return userDetail;
        }

        public async Task<UserDetailViewModel> GetUserDetail(string userName)
        {
            var userDetail = await _httpClient.GetFromJsonAsync<UserDetailViewModel>($"/api/user/userName/{userName}");
            return userDetail;
        }

        public async Task<bool> UpdateUser(UserDetailViewModel user)
        {
            var result = await _httpClient.PostAsJsonAsync($"/api/user/update", user);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> ChangeUserPassword(string oldPassword, string newPassword)
        {
            var command = new ChangeUserPasswordCommand(null, oldPassword, newPassword);
            var httpResponse = await _httpClient.PostAsJsonAsync($"/api/User/ChangePassword", command);
            if (httpResponse!=null && !httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode ==HttpStatusCode.BadRequest)
                {
                    var responseStr = await httpResponse.Content.ReadAsStringAsync();
                    var validation = JsonSerializer.Deserialize<ValidationResponseModel>(responseStr);
                    responseStr = validation.FlattenError;
                    throw new DataBaseValidationException(responseStr);
                }

                return false;
            }

            return httpResponse.IsSuccessStatusCode;
        }
    }
}
