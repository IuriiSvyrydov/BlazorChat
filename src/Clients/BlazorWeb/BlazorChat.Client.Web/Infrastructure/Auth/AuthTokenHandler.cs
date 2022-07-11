using System.Net.Http.Headers;
using BlazorChat.Client.Web.Infrastructure.Extensions;
using Blazored.LocalStorage;

namespace BlazorChat.Client.Web.Infrastructure.Auth;

public class AuthTokenHandler: DelegatingHandler
{
    private readonly  ISyncLocalStorageService _syncLocalStorageService;

    public AuthTokenHandler(ISyncLocalStorageService syncLocalStorageService)
    {
        _syncLocalStorageService = syncLocalStorageService;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = _syncLocalStorageService.GetToken();
        if (!string.IsNullOrEmpty(token)&&request.Headers.Authorization is null)
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer",token  );
        return base.SendAsync(request, cancellationToken);
    }
}