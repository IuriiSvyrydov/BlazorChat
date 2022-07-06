using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Api.Domain.Models;
using BlazorChat.Api.Infrastructure.Persistence.Context;

namespace BlazorChat.Api.Application.Repositories;

public class EntryCommentRepository: GenericRepository<EntryComment>,IEntryCommentRepository
{
    public EntryCommentRepository(BlazorChatContext context) : base(context)
    {
    }
}