using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yeditepe.Business.Abstract.Accounts;
using Yeditepe.Business.Repositories;
using Yeditepe.Business.Validations.Accounts;
using Yeditepe.DataAccess.Repositories;
using Yeditepe.Entities.Accounts;
using Yeditepe.Models.Accounts;
using Yeditepe.Models.Filters;
using YtsFramework.NETCore.Aspects.Caching;
using YtsFramework.NETCore.Aspects.Security;
using YtsFramework.NETCore.Aspects.Validation;
using YtsFramework.NETCore.Models;
using YtsFramework.NETCore.Utilities.Results;

namespace Yeditepe.Business.Concrete.Accounts
{
    [SecurityAspect]
    [ValidationAspect(typeof(RoleValidator))]
    public class RoleService : ServiceRepository<Role, RoleModel>, IRoleService
    {
        private readonly IDalRepository<Role> _dal;

        public RoleService(IDalRepository<Role> dal) => _dal = dal;

        [CacheAspect]
        public async Task<PagedResponse<Role, RolesModel>> GetAllAsync(FilterModel filter)
        {
            var query = _dal.TableNoTracking;
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                var keyword = filter.Keyword.ToLower();
                query = query.Where(x => x.Description.ToLower().Contains(keyword));
            }
            return new PagedResponse<Role, RolesModel>(await PagedList<Role>.ToListAsync(query, filter.PageNumber, filter.PageSize));
        }

        [CacheAspect]
        public async Task<List<SelectList>> SelectAsync() => await _dal.TableNoTracking.Where(x => !x.IsBlocked).OrderBy(x => x.Description).Select(x => new SelectList
        {
            Id = x.Id,
            Description = x.Description
        }).ToListAsync();

    }
}
