using YtsFramework.NETCore.Signatures;

namespace Yeditepe.DataAccess.Repositories
{
    public interface ISqlRepository<TQuery> : YtsFramework.NETCore.Repositories.ISqlRepository<TQuery> where TQuery : class, IBaseQuery, new()
    {

    }
}