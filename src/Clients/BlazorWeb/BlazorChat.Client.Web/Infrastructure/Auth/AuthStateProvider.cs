using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BlazorChat.Client.Web.Infrastructure.Extensions;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorChat.Client.Web.Infrastructure.Auth;

public class AuthStateProvider:AuthenticationStateProvider
{
    private readonly  ILocalStorageService _localStorageService;
    private readonly AuthenticationState _provider;

    public AuthStateProvider(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
        _provider = new AuthenticationState(new ClaimsPrincipal
            (new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var apiToken = await _localStorageService.GetToken();
        if (string.IsNullOrEmpty(apiToken))
            return _provider;
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadJwtToken(apiToken);
        var cp = new ClaimsPrincipal(new ClaimsIdentity(securityToken.Claims,"jwtAuthType"));
        return new AuthenticationState(cp);
    }

    public void NotifyUserLogin(string userName,Guid userId)
    {
        var cp = new ClaimsPrincipal(new ClaimsIdentity(new []
        { 
            new Claim(ClaimTypes.Name,userName),
            new Claim(ClaimTypes.NameIdentifier,userId.ToString())

        }, "jwtAuthType"));  
        var authState = Task.FromResult(new AuthenticationState(cp)); 
        NotifyAuthenticationStateChanged(authState);
    }

    public void NotifyUserLogout()
    {
        var authState = Task.FromResult(_provider);
        NotifyAuthenticationStateChanged(authState);
    }
 }