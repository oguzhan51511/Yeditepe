using System;
using YtsFramework.NETCore.Signatures;

namespace Yeditepe.Entities.Accounts
{
    public class AccountLoginHistory : IBaseEntity
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string IpAddress { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public Account Account { get; set; }
    }
}