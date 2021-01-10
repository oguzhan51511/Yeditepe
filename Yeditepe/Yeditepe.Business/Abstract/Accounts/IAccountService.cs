using System.Collections.Generic;
using System.Threading.Tasks;
using Yeditepe.Business.Repositories;
using Yeditepe.Entities.Accounts;
using Yeditepe.Models.Accounts;
using Yeditepe.Models.Filters;
using YtsFramework.NETCore.Utilities.Results;

namespace Yeditepe.Business.Abstract.Accounts
{
    public interface IAccountService : IServiceRepository<AccountModel>
    {
        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <returns>IEnumerable Entities</returns>
        Task<PagedResponse<Account, AccountsModel>> GetAllAsync(int? roleId,FilterModel filter);

        /// <summary>
        /// Get Histories
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<List<AccountLoginHistoriesModel>> HistoriesAsync(int accountId);
    }
}