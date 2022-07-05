using BlazorChat.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorChat.Api.Infrastructure.Persistence.EntityConfiguration.Entry;

public class EntryEntityConfiguration : BaseEntityConfiguration<Domain.Models.Entry>
{
    public override void Configure(EntityTypeBuilder<Domain.Models.Entry> builder)
    {
        builder.ToTable("entry", BlazorChatContext.DEFAULT_SCHEMA);
        base.Configure(builder);
        
        builder.HasOne(i => i.CreateBy)
            .WithMany(i => i.Entries)
            .HasForeignKey(i => i.CreateById);

    }
}