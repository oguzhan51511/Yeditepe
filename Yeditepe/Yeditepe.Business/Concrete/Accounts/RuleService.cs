using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Yeditepe.Business.Abstract.Accounts;
using Yeditepe.Business.Repositories;
using Yeditepe.Business.Validations.Accounts;
using Yeditepe.DataAccess.Repositories;
using Yeditepe.Entities.Accounts;
using Yeditepe.Models.Accounts;
using YtsFramework.NETCore.Aspects.Caching;
using YtsFramework.NETCore.Aspects.Security;
using YtsFramework.NETCore.Aspects.Validation;

namespace Yeditepe.Business.Concrete.Accounts
{
    [SecurityAspect]
    [ValidationAspect(typeof(RuleValidator))]
    public class RuleService : ServiceRepository<Rule, RuleModel>, IRuleService
    {
        private readonly IDalRepository<Rule> _dal;
        public RuleService(IDalRepository<Rule> dal) => _dal = dal;

        [CacheAspect]
        public async Task<List<RulesModel>> GetAllAsync(int roleId)
        {
            var modules = ModuleList.ToList();
            var entities = await _dal.TableNoTracking.OrderByDescending(x => x.Module).Where(x => x.RoleId == roleId).ToListAsync();

            var result =
                from m in modules
                join x in entities on m equals x.Module into ps
                from x in ps.DefaultIfEmpty()
                select new RulesModel
                {
                    Id = x?.Id ?? 0,
                    Module = m,
                    View = x?.View ?? false,
                    Insert = x?.Insert ?? false,
                    Update = x?.Update ?? false,
                    Delete = x?.Delete ?? false,
                    ModuleDescription = m.Pluralize()//Translate İşlemi Yapılacak
                };

            return result.ToList();
        }

    }
}
