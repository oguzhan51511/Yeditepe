using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
using YtsFramework.NETCore.Plugins.Authentication.Models;
using YtsFramework.NETCore.Utilities.Results;

namespace Yeditepe.Business.Concrete.Accounts
{
    [SecurityAspect]
    [ValidationAspect(typeof(AccountValidator))]
    public class AccountService : ServiceRepository<Account, AccountModel>, IAccountService
    {
        private readonly IDalRepository<Account> _dal;
        private readonly IDalRepository<AccountLoginHistory> _historyDal;
        private readonly IMapper _mapper;

        public AccountService(IDalRepository<Account> dal, IMapper mapper, IDalRepository<AccountLoginHistory> historyDal)
        {
            _dal = dal;
            _mapper = mapper;
            _historyDal = historyDal;
        }

        [CacheAspect]
        public async Task<PagedResponse<Account, AccountsModel>> GetAllAsync(int? roleId,FilterModel filter)
        {
            var query = _dal.IncludeMany(r => r.Role);
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                var keyword = filter.Keyword.ToLower();
                query = query.Where(x =>(x.FirstName.ToLower() + " " +x.LastName.ToLower()).Contains(keyword) || x.Email.ToLower().Contains(keyword));
            }
            if (roleId != null) query = query.Where(x => x.RoleId == roleId);
            return new PagedResponse<Account, AccountsModel>(await PagedList<Account>.ToListAsync(query, filter.PageNumber, filter.PageSize));
        }

        [CacheAspect]
        [SecurityAspect(RuleType.View)]
        public async Task<List<AccountLoginHistoriesModel>> HistoriesAsync(int accountId) => _mapper.Map<List<AccountLoginHistoriesModel>>(await _historyDal.TableNoTracking.Where(x => x.AccountId == accountId).ToListAsync());
    }
}
