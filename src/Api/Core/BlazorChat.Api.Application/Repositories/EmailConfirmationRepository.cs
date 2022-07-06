

using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Api.Domain.Models;
using BlazorChat.Api.Infrastructure.Persistence.Context;

namespace BlazorChat.Api.Application.Repositories
{
    public class EmailConfirmationRepository: GenericRepository<EmailConfirmation>,IEmailConfirmRepository
    {
        public EmailConfirmationRepository(BlazorChatContext context) : base(context)
        {
        }
    }
}
