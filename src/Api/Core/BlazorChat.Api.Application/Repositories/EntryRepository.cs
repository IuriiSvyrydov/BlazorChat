using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Api.Domain.Models;
using BlazorChat.Api.Infrastructure.Persistence.Context;

namespace BlazorChat.Api.Application.Repositories;

public class EntryRepository:GenericRepository<Entry> ,IEntryRepository
{
    public EntryRepository(BlazorChatContext context) : base(context)
    {
    }
}