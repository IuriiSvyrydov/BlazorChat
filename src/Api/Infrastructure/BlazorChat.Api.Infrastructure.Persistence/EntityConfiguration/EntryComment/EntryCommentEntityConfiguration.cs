using BlazorChat.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorChat.Api.Infrastructure.Persistence.EntityConfiguration.EntryComment;

public class EntryCommentEntityConfiguration: BaseEntityConfiguration<Domain.Models.EntryComment>
{
    public override void Configure(EntityTypeBuilder<Domain.Models.EntryComment> builder)
    {
        base.Configure(builder);
        builder.ToTable("entryComment", BlazorChatContext.DEFAULT_SCHEMA);
        builder.HasOne(x => x.CreateBy)
            .WithMany(x => x.EntryComments)
            .HasForeignKey(x => x.EntryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Entry)
            .WithMany(x => x.EntryComments)
            .HasForeignKey(x => x.EntryId);
    }
}