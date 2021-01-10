using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yeditepe.Entities.Accounts;

namespace Yeditepe.DataAccess.Mappings.EF.Accounts
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts"); 
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.FirstName).HasMaxLength(35);
            builder.Property(x => x.LastName).HasMaxLength(30);
            builder.Property(x => x.Gsm).HasMaxLength(11);
            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
        }
    }
}
