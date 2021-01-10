using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yeditepe.Entities.Accounts;

namespace Yeditepe.DataAccess.Mappings.EF.Accounts
{
    public class RuleMap : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {
            builder.ToTable("Rules");
            builder.HasIndex(x => new { x.RoleId, x.Module }).IsUnique();
            builder.Property(x => x.Module).HasMaxLength(100);
        }
    }
}
