using System.Linq;
using Yeditepe.Entities.Accounts;
using YtsFramework.NETCore.Helpers;

namespace Yeditepe.DataAccess.Seeds
{
    public static class SeedManager
    {
        public static void SeedData(YeditepeContext context)
        {
            Seed(context);
        }

        private static void Seed(YeditepeContext context)
        {
            if (!context.Accounts.Any(x => x.Email == "baseproject@blabla.com"))
            {
                HashingHelper.CreatePasswordHash("1", out var passwordHash, out var passwordSalt);
                context.Accounts.Add(new Account
                {
                    Id = 0,
                    FirstName = "Base",
                    LastName = "Project",
                    Email = "baseproject@blabla.com",
                    Gsm = "5320000000",
                    IsBlocked = false,
                    IsSuperVisor = true,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                });
                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }
}
