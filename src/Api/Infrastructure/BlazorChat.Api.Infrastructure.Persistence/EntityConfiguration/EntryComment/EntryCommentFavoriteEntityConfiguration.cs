using BlazorChat.Api.Domain.Models;
using BlazorChat.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorChat.Api.Infrastructure.Persistence.EntityConfiguration.EntryComment;

public class EntryCommentFavoriteEntityConfiguration : BaseEntityConfiguration<EntryCommentFavorite>
{
    public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
    {
        base.Configure(builder);
        builder.ToTable("entryCommentFavorite", BlazorChatContext.DEFAULT_SCHEMA);
        builder.HasOne(i => i.EntryComment)
            .WithMany(i => i.EntryCommentFavorites)
            .HasForeignKey(i => i.EntryCommentId);
        builder.HasOne(i => i.CreateUser)
            .WithMany(i => i.EntryCommentFavorites)
            .HasForeignKey(i => i.CreateById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}