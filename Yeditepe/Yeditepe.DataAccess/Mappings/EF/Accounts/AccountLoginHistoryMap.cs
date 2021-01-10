using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yeditepe.Entities.Accounts;

namespace Yeditepe.DataAccess.Mappings.EF.Accounts
{
    public class AccountLoginHistoryMap : IEntityTypeConfiguration<AccountLoginHistory>
    {
        public void Configure(EntityTypeBuilder<AccountLoginHistory> builder)
        {
            builder.ToTable("AccountLoginHistories");
        }
    }
}
