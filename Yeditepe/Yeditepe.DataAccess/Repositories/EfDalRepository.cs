using Microsoft.Extensions.DependencyInjection;
using YtsFramework.NETCore.Repositories.EF;
using YtsFramework.NETCore.Signatures;
using YtsFramework.NETCore.Utilities.IoC;

namespace Yeditepe.DataAccess.Repositories
{
    public class EfDalRepository<TEntity> : EfRepository<TEntity, YeditepeContext>, IDalRepository<TEntity> where TEntity : class, IBaseEntity, new()
    {
        public EfDalRepository() : base(ServiceTool.ServiceProvider.GetService<YeditepeContext>())
        {

        }
    }
}