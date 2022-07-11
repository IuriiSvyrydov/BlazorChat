using System.Runtime.InteropServices;
using Blazored.LocalStorage;

namespace BlazorChat.Client.Web.Infrastructure.Extensions
{
    public static class LocalStorageExtension
    {
        public const string TokenName = "token";
        public const string UserName = "userName";
        public const string UserId = "userId";

        public static bool IsUserLoggedIn(this ISyncLocalStorageService localStorageService)
        {
            return !string.IsNullOrEmpty(GetToken(localStorageService));
        }

        public static string GetUserName(this ISyncLocalStorageService localStorageService)
        {
            return localStorageService.GetItem<string>(UserName);
        }

        public static async Task<string> GetUserName(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<string>(UserName);
        }

        public static void SetUserName(this ISyncLocalStorageService localStorageService, string value)
        {
            localStorageService.SetItem(UserName,value);
        }
        public static void SetToken(this ISyncLocalStorageService localStorageService,string value)
        {
            localStorageService.SetItem(TokenName,value);
        }

        public static async Task SetToken(this ILocalStorageService localStorageService, string value)
        {
            await localStorageService.SetItemAsStringAsync(TokenName, value);
        }

        public static Guid GetUserId(this ISyncLocalStorageService localStorageService)
        {
            return localStorageService.GetItem<Guid>(UserId);
        }

        public static void SetUserId(this ISyncLocalStorageService localStorageService, Guid id)
        {
            localStorageService.SetItem(UserId,id);
        }

        public static async Task<Guid> GetUserId(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<Guid>(UserId);
        }

        public static string GetToken(this ISyncLocalStorageService localStorageService)
        {
            var token = localStorageService.GetItem<string>(TokenName);
            //if (string.IsNullOrEmpty(token))
                //token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImVkNTI3NmQwLWRlZGUtNDc3NC1hZTg5LTAwMDFlYzM2MWI2OSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6IkJ1ZGFrNzRAeWFob28uY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkFscGJpbGdlLkJhc29nbHUiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9naXZlbm5hbWUiOiJTdXphbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJHw7xtw7zFn3BhbGEiLCJuYmYiOjE2NTc1Mjk0MjQsImV4cCI6MTY1ODM5MzQyM30.2zSIO1SYMv0or5SYnWw1b-021OTrNycFXokHXslU1_0";
            return token;
        }

        public static async Task<string> GetToken(this ILocalStorageService localStorageService)
        {
            var token = await localStorageService.GetItemAsync<string>(TokenName);
            //if (string.IsNullOrEmpty(token))
            //    token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImVkNTI3NmQwLWRlZGUtNDc3NC1hZTg5LTAwMDFlYzM2MWI2OSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6IkJ1ZGFrNzRAeWFob28uY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkFscGJpbGdlLkJhc29nbHUiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9naXZlbm5hbWUiOiJTdXphbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJHw7xtw7zFn3BhbGEiLCJuYmYiOjE2NTc1Mjk0MjQsImV4cCI6MTY1ODM5MzQyM30.2zSIO1SYMv0or5SYnWw1b-021OTrNycFXokHXslU1_0";
            return token;
        }
    }
}
