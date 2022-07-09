using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlazorChat.Api.WebApi.Infrastructure.ActionFilter;

public class ValidationFilter: IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var messages = context.ModelState.Values.SelectMany(x => x.Errors)
                .Select(x => !string.IsNullOrEmpty(x.ErrorMessage) ? x.ErrorMessage : x.Exception?.Message)
                .Distinct().ToList();
            return;

        }

        await next();
    }
}