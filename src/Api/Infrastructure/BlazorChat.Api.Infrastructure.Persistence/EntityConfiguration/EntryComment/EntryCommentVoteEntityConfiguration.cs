using BlazorChat.Api.Domain.Models;
using BlazorChat.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorChat.Api.Infrastructure.Persistence.EntityConfiguration.EntryComment;

public class EntryCommentVoteEntityConfiguration :BaseEntityConfiguration<EntryCommentVote>
{
    public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
    {
        base.Configure(builder);
        builder.ToTable("entryCommentVote", BlazorChatContext.DEFAULT_SCHEMA);
        builder.HasOne(e => e.EntryComment)
            .WithMany(e => e.EntryCommentVotes)
            .HasForeignKey(e => e.EntryCommentId);
    }
}