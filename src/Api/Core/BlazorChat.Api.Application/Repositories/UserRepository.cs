
using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Api.Domain.Models;
using BlazorChat.Api.Infrastructure.Persistence.Context;

namespace BlazorChat.Api.Application.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(BlazorChatContext context) : base(context)
        {
        }
    }
}
