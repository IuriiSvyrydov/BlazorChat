

using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorChat.Api.Application.Extentions
{
    public static class Registration
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            var aasm = Assembly.GetExecutingAssembly();
            services.AddMediatR(aasm);
            services.AddAutoMapper(aasm);
            services.AddValidatorsFromAssembly(aasm);
            return services;
        }
    }
}
