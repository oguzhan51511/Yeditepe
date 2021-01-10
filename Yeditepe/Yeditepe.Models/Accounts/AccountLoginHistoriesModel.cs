using System;

namespace Yeditepe.Models.Accounts
{
    public class AccountLoginHistoriesModel
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}