using System.Collections.Generic;
using System.Threading.Tasks;
using Yeditepe.Business.Repositories;
using Yeditepe.Entities.Accounts;
using Yeditepe.Models.Accounts;
using Yeditepe.Models.Filters;
using YtsFramework.NETCore.Models;
using YtsFramework.NETCore.Utilities.Results;

namespace Yeditepe.Business.Abstract.Accounts
{
    public interface IRoleService : IServiceRepository<RoleModel>
    {

        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <returns>IEnumerable Entities</returns>
        Task<PagedResponse<Role,RolesModel>> GetAllAsync(FilterModel filter);

        /// <summary>
        /// Select List
        /// </summary>
        /// <returns>Return SelectModel list</returns>
        Task<List<SelectList>> SelectAsync();

    }
}