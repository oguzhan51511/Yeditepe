using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YtsFramework.NETCore.Plugins.Logger.Entities;

namespace Yeditepe.DataAccess.Mappings.EF.Settings
{
    public class EntityHistoryMap : IEntityTypeConfiguration<EntityHistory>
    {
        public void Configure(EntityTypeBuilder<EntityHistory> builder)
        {
            builder.ToTable("EntityHistories");
            builder.HasIndex(x => x.EntityName);
            builder.HasIndex(x => new { x.EntityId, x.EntityName });

            builder.Property(x => x.EntityId).HasMaxLength(10);
            builder.Property(x => x.EntityName).HasMaxLength(100);
            builder.Property(x => x.LogType).HasMaxLength(50);
            builder.Property(x => x.UserName).HasMaxLength(50);
        }
    }
}