using YtsFramework.NETCore.Signatures;

namespace Yeditepe.Entities.Accounts
{
    public class Rule : IBaseEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Module { get; set; }
        public bool View { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }

        public Role Role { get; set; }
    }
}