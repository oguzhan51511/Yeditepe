namespace Yeditepe.Models.Accounts
{
    public class AccountsModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public string UserGroup { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsSuperVisor { get; set; }
        public string RoleName { get; set; }
    }
}
