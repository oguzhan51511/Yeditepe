using Microsoft.Extensions.DependencyInjection;
using YtsFramework.NETCore.Repositories.EF;
using YtsFramework.NETCore.Signatures;
using YtsFramework.NETCore.Utilities.IoC;

namespace Yeditepe.DataAccess.Repositories
{
    public class EfSqlRepository<TQuery> : EfSqlRepository<TQuery, YeditepeContext>, ISqlRepository<TQuery> where TQuery : class, IBaseQuery, new()
    {
        public EfSqlRepository() : base(ServiceTool.ServiceProvider.GetService<YeditepeContext>())
        {

        }
    }
}
