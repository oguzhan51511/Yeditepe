using YtsFramework.NETCore.Repositories;
using YtsFramework.NETCore.Signatures;

namespace Yeditepe.DataAccess.Repositories
{
    public interface IDalRepository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity, new()
    {

    }
}