using System;
using YtsFramework.NETCore.Signatures;

namespace Yeditepe.Entities.Accounts
{
    public class PasswordChangeRequest : IBaseEntity
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Token { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime? UsedAt { get; set; }

        public Account Account { get; set; }
    }
}