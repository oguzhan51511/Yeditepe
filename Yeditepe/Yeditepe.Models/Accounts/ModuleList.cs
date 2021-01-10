using System.Collections.Generic;

namespace Yeditepe.Models.Accounts
{
    public class ModuleList:List<string>
    {
        private ModuleList(IEnumerable<string> items)
        {
            AddRange(items);
        }

        public static IEnumerable<string> ToList()
        {
            var items = new List<string>
            {
                "Account", 
                "Role",
            };
            return new ModuleList(items);
        }
    }
}
