
using System.Reflection;
using BlazorChat.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Api.Infrastructure.Persistence.Context
{
    public class BlazorChatContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public BlazorChatContext()
        {
            
        }
        public BlazorChatContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<User>Users { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryVote> EntryVotes { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }
        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conString = "Server=DESKTOP-7CB8L9L\\SQLEXPRESS;Database=BlazorChatDb;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(conString, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntity = ChangeTracker.Entries().Where(i => i.State == EntityState.Added)
                .Select(i=>(BaseEntity)i.Entity);
            PrepareAddedEntity(addedEntity);

        }

        private void PrepareAddedEntity(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.CreateDate==DateTime.MinValue)
                    entity.CreateDate = DateTime.Now;
            }
        }
    }
}
