using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BlazorChat.Client.Web.Infrastructure.Auth;
using BlazorChat.Client.Web.Infrastructure.Extensions;
using BlazorChat.Client.Web.Infrastructure.Interfaces;
using BlazorChat.Common.Exceptions;
using BlazorChat.Common.Infrastructure.Results;
using BlazorChat.Common.Models.Queries;
using BlazorChat.Common.Models.RequestModel;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorChat.Client.Web.Infrastructure.Services
{
    public class IdentityService: IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly ISyncLocalStorageService _syncLocalStorageService;
        private readonly AuthenticationStateProvider _authProvider;

        public IdentityService(HttpClient httpClient, ISyncLocalStorageService syncLocalStorageService, AuthenticationStateProvider authProvider)
        {
            _httpClient = httpClient;
            _syncLocalStorageService = syncLocalStorageService;
            _authProvider = authProvider;
        }

        public bool IsLoggedIn => !string.IsNullOrEmpty(GetUserToken());

        public string GetUserToken()
        {
            return _syncLocalStorageService.GetToken();
        }
        public string GetUserName()
        {
            return _syncLocalStorageService.GetToken();
        }

        public Guid GetUserId()
        {
            return _syncLocalStorageService.GetUserId();
        }

        public async Task<bool> Login(LoginUserCommand command)
        {
            string responseStr;
            var httpResponse = await _httpClient.PostAsJsonAsync("/", command);
            if (httpResponse!=null&& !httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode==HttpStatusCode.BadRequest)
                {
                    responseStr = await httpResponse.Content.ReadAsStringAsync();
                    var validation = JsonSerializer.Deserialize<ValidationResponseModel>(responseStr);
                    responseStr = validation.FlattenError;
                    throw new DataBaseValidationException(responseStr);
                }

                return false;
            }

            responseStr = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<LoginUserViewModel>(responseStr);
            if (!string.IsNullOrEmpty(response.Token))
            {
                _syncLocalStorageService.SetToken(response.Token);
                _syncLocalStorageService.SetUserName(response.UserName);
                _syncLocalStorageService.SetUserId(response.Id);
                ((AuthStateProvider)_authProvider).NotifyUserLogin(response.UserName, response.Id);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",response.UserName);
                return true;
            }

            return false;
        }


        public void Logout()
        {
            _syncLocalStorageService.RemoveItem(LocalStorageExtension.TokenName);
            _syncLocalStorageService.RemoveItem(LocalStorageExtension.UserName);
            _syncLocalStorageService.RemoveItem(LocalStorageExtension.UserId);
            ((AuthStateProvider)_authProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

    }
}
