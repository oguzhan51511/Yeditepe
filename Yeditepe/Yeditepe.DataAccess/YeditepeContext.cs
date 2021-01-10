using Microsoft.EntityFrameworkCore;
using Yeditepe.DataAccess.Extensions;
using Yeditepe.Entities.Accounts;
using YtsFramework.NETCore.Plugins.Logger.Entities;

namespace Yeditepe.DataAccess
{
    public class YeditepeContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountLoginHistory> AccountLoginHistories { get; set; }
        public DbSet<PasswordChangeRequest> PasswordChangeRequests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<EntityHistory> EntityHistories { get; set; }

        public YeditepeContext()
        {

        }

        public YeditepeContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb = mb.SetDataType();
            mb = mb.MapConfiguration();
            base.OnModelCreating(mb);
        }
    }
}
