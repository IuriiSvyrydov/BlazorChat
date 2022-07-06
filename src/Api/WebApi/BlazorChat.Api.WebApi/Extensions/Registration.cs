using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Api.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorChat.Api.WebApi.Extensions;

public static class Registration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEntryRepository, EntryRepository>();
        return services;
    }
}