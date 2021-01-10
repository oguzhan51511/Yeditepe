using YtsFramework.NETCore.Signatures;

namespace Yeditepe.Models.Accounts
{
    public class AccountModel : IBaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public string ErpCode { get; set; }
        public bool IsBlocked { get; set; }
        public bool SendSms { get; set; }
        public bool SendEmail { get; set; }
        public int UserGroupId { get; set; }
        public bool IsSuperVisor { get; set; } 
        public int? RoleId { get; set; }
    }
}