

using BlazorChat.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorChat.Api.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlazorChatContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), conf =>
                {
                    conf.EnableRetryOnFailure();
                }));
            var seedData = new SeedData();
            seedData.SeedAsync(configuration).GetAwaiter().GetResult();
            return services;
        }
    }
}
