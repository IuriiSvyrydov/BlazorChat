
using BlazorChat.Api.Domain.Models;
using BlazorChat.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorChat.Api.Infrastructure.Persistence.EntityConfiguration
{
    public class EmailConfirmedEntityConfiguration: BaseEntityConfiguration<EmailConfirmation>
    {
        public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            base.Configure(builder);
            builder.ToTable("emailConfirmation", BlazorChatContext.DEFAULT_SCHEMA);
        }
    }
}
