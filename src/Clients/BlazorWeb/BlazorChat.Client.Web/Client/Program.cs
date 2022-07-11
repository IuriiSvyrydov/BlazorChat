using BlazorChat.Client.Web.Infrastructure.Auth;
using BlazorChat.Client.Web.Infrastructure.Interfaces;
using BlazorChat.Client.Web.Infrastructure.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorChat.Client.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient("WebApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001");
            }).AddHttpMessageHandler<AuthTokenHandler>();
            builder.Services.AddScoped(sp =>
            {
                var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
                return clientFactory.CreateClient("WebApiClient");
            });
            builder.Services.AddScoped<AuthTokenHandler>(); 
            builder.Services.AddTransient<IEntryService, EntryService>();
            builder.Services.AddTransient<IVoteService, VoteService>();
            builder.Services.AddTransient<IFavService, FavService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

          //  builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
          builder.Services.AddBlazoredLocalStorage();
          builder.Services.AddAuthorizationCore();
            await builder.Build().RunAsync();
        }
    }
}