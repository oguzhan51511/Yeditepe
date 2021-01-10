using System.Collections.Generic;
using System.Threading.Tasks;
using Yeditepe.Business.Repositories;
using Yeditepe.Models.Accounts;

namespace Yeditepe.Business.Abstract.Accounts
{
    public interface IRuleService : IServiceRepository<RuleModel>
    {
        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <returns>IEnumerable Entities</returns>
        Task<List<RulesModel>> GetAllAsync(int roleId);
    }
}