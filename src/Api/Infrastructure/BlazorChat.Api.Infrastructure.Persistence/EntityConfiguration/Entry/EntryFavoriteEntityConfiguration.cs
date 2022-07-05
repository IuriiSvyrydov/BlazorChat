using BlazorChat.Api.Domain.Models;
using BlazorChat.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorChat.Api.Infrastructure.Persistence.EntityConfiguration.Entry;

public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<EntryFavorite>
{
    public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
    {
        base.Configure(builder);
        builder.ToTable("etryFavorite", BlazorChatContext.DEFAULT_SCHEMA);
        builder.HasOne(i => i.Entry)
            .WithMany(i => i.EntryFavorites)
            .HasForeignKey(i => i.EntryId);
        builder.HasOne(i=>i.CreateUser)
                .WithMany(i=>i.EntryFavorites)
                .HasForeignKey(i=>i.CreateById )
                .OnDelete(DeleteBehavior.Restrict);
    }
}