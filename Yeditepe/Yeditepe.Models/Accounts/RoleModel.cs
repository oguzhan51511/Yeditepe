using YtsFramework.NETCore.Signatures;

namespace Yeditepe.Models.Accounts
{
    public class RoleModel:IBaseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsBlocked { get; set; }
    }
}
