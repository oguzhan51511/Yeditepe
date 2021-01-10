using YtsFramework.NETCore.Signatures;

namespace Yeditepe.Entities.Accounts
{
    public class Account : IBaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsSuperVisor { get; set; }
        public int? RoleId { get; set; }

        public Role Role { get; set; }
    }
}
