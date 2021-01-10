using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yeditepe.Entities.Accounts;

namespace Yeditepe.DataAccess.Mappings.EF.Accounts
{
    public class PasswordChangeRequestMap : IEntityTypeConfiguration<PasswordChangeRequest>
    {
        public void Configure(EntityTypeBuilder<PasswordChangeRequest> builder)
        {
            builder.ToTable("PasswordChangeRequests");
            builder.HasIndex(x => x.Token).IsUnique();
            builder.Property(x => x.Token).HasMaxLength(255);
        }
    }
}
