using System.Collections.Generic;
using YtsFramework.NETCore.Signatures;

namespace Yeditepe.Entities.Accounts
{
    public class Role : IBaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsBlocked { get; set; }


        public ICollection<Rule> Rules { get; set; }
    }
}