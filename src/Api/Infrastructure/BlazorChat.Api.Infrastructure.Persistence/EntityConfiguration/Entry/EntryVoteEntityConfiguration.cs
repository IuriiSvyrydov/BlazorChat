using BlazorChat.Api.Domain.Models;
using BlazorChat.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorChat.Api.Infrastructure.Persistence.EntityConfiguration.Entry
{
    public class EntryVoteEntityConfiguration:BaseEntityConfiguration<EntryVote>
    {
        public override void Configure(EntityTypeBuilder<EntryVote> builder)
        {
            base.Configure(builder);
            builder.ToTable("entryVote", BlazorChatContext.DEFAULT_SCHEMA);
            builder.HasOne(e => e.Entry)
                .WithMany(e => e.EntryVotes)
                .HasForeignKey(e => e.EntryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
